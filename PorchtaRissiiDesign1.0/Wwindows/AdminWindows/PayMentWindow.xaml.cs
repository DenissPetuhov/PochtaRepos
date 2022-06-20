using PorchaAPI;
using PorchtaRissiiDesign1._0.Utils;
using PorchtaRissiiDesign1._0.Wwindows.PageRedakt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static PorchtaRissiiDesign1._0.App;


namespace PorchtaRissiiDesign1._0.Wwindows.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для PayMentWindow.xaml
    /// </summary>
    public partial class PayMentWindow : Window, INotifyPropertyChanged
    {
        public PayMentWindow()
        {
            InitializeComponent();
            UpdateDate();
        }

        public async void UpdateDate()
        {
            PaymentHumen = await HttpRequest.GetAsync<List<PaymentHuman>>($"{adress}Home/PaymentHumans");
            FiltredPaymentHumen = PaymentHumen;
            AllPaymens = await HttpRequest.GetAsync<List<Payment>>($"{adress}Home/Payments");

        }

        private List<PaymentHuman> _paymentHuman;
        public List<PaymentHuman> PaymentHumen { get => _paymentHuman; set { _paymentHuman = value; OnPropertyChanged(); } }
        private List<PaymentHuman> _filtredPaymentHumen;
        public List<PaymentHuman> FiltredPaymentHumen { get => _filtredPaymentHumen; set { _filtredPaymentHumen = value; OnPropertyChanged(); } }

        private List<Payment> payments;
        public List<Payment> AllPaymens
        {
            get { return payments; }
            set { payments = value; OnPropertyChanged(); }
        }
        private List<Payment> fpayments;
        public List<Payment> FiltredPayments { get => fpayments; set { fpayments = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        public PaymentHuman paymentHumanSelectItem;
        private void MouseDoubleCLikPaymaentHuman(object sender, MouseButtonEventArgs e)
        {
            FiltredPayments = null;
            paymentHumanSelectItem = (PaymentHuman)PaymentHumanListView.SelectedValue;

            FiltredPayments = FiltrPay(paymentHumanSelectItem);
            PhoneNumberTextBlock.Text = paymentHumanSelectItem.PhoneNumber.ToString();
            NameTextBlock.Text = paymentHumanSelectItem.Name.ToString();
            DiscriptionTextBLock.Text = paymentHumanSelectItem.Discript.ToString();
            ApartemetsTextBlock.Text = paymentHumanSelectItem.IdApartamentNavigation.Number.ToString();
            HomeTextBlock.Text = paymentHumanSelectItem.IdApartamentNavigation.IdBuildingNavigation.NumberBuilding.ToString();
        }
        public List<Payment> FiltrPay(PaymentHuman item)
        {
            try
            {
                List<Payment> list = new List<Payment>();
                list = AllPaymens.Where(x => x.IdHuman == item.Id).ToList();
                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public string _search;
        public string SearchText { get => _search; set { _search = value; Search(); } }
        private void Search()
        {
            FiltredPaymentHumen = PaymentHumen;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
              return;
            }
            FiltredPaymentHumen = FiltredPaymentHumen.Where(s => s.Name.ToLower().Contains(SearchText.ToLower())).ToList();
        }
        private void MouseDubleClick_PaymetsListView(object sender, MouseButtonEventArgs e)
        {
            //Payment PaymentSelectitem = (Payment)ListViewPayment.SelectedValue;
        }


        public double sum1;
        public double sum2;
        public double sum3;
        public double allAmount;

        private void DragMove_MousedounLogo(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private async void SaveDataBtn_click(object sender, RoutedEventArgs e)
        {

            if (paymentHumanSelectItem != null)
            {
                try
                {
                    sum1 = 0;
                    sum2 = 0;
                    sum3 = 0;
                    allAmount = 0;
                    if (TextBoxOneSumm.Text != "")
                        sum1 += Convert.ToDouble(TextBoxOneSumm.Text);
                    else if (TextBoxTwoSumm.Text == "")
                        sum1 = 0;

                    if (TextBoxTwoSumm.Text != "")
                        sum2 += Convert.ToDouble(TextBoxTwoSumm.Text);
                    else if (TextBoxTwoSumm.Text == "")
                        sum2 = 0;

                    if (TextBoxThreeSumm.Text != "")
                        sum3 += Convert.ToDouble(TextBoxThreeSumm.Text);
                    else if (TextBoxThreeSumm.Text == "")
                        sum3 = 0;

                    allAmount = sum1 + sum2 + sum3;
                    TextBLockCountItog.Text = allAmount.ToString();
                    double[] billAgrs;
                    billAgrs = BilletCounter.BillCounts(allAmount); // Возарвщает массив от где 0 элемент это 5000 купюры а 50 - 6 элемент  а 7 элемент это остаток монет
                    Payment paymentCount = new Payment
                    {
                        IdHuman = paymentHumanSelectItem.Id,
                        Amount1 = ((decimal)sum1),
                        Amount2 = ((decimal)sum2),
                        Amount3 = ((decimal)sum3),
                        CountAmount = ((decimal)allAmount),
                        CountBillTire1 = (int)billAgrs[0],
                        CountBillTire2 = (int)billAgrs[1],
                        CountBillTire3 = (int)billAgrs[2],
                        CountBillTire4 = (int)billAgrs[3],
                        CountBillTire5 = (int)billAgrs[4],
                        CountBillTire6 = (int)billAgrs[5],
                        CountBillTire7 = (int)billAgrs[6],
                        CountCoins = (decimal)Math.Round(billAgrs[7], 2),
                        Date = DateTime.Now,
                    };



                    await HttpRequest.PostAsync<bool>($"{adress}Home/addNewPayments", paymentCount);
                    MessageBox.Show("успешно");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            UpdateDate();
            FiltredPayments = FiltrPay(paymentHumanSelectItem);

        }

        private void AddNewObjBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }
        private void DeleteImage_MouseDouwn(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeletePaymentTextBox(object sender, MouseButtonEventArgs e)
        {

        }

        private void DatePickerSelectPaymentsFiltr_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if(FiltredPayments != null)
            {
                FiltredPayments = FiltrPay(paymentHumanSelectItem);
                DateTime? date = DatePickerSelectPaymentsFiltr.SelectedDate;
                FiltredPayments = FiltredPayments.Where(x => x.Date.Value.Date == date.Value.Date).ToList();
            }   
        }

      

        private void CancelSearhc_Button(object sender, RoutedEventArgs e)
        {
         
        }
    }
}
