using PorchaAPI;
using PorchtaRissiiDesign1._0.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static PorchtaRissiiDesign1._0.App;


namespace PorchtaRissiiDesign1._0.Wwindows
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


        public List<PaymentHuman> FiltredPaymentHumen { get => _paymentHuman; set { _paymentHuman = value; OnPropertyChanged(); } }

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
        public PaymentHuman item ;
        private  void MouseDoubleCLikPaymaentHuman(object sender, MouseButtonEventArgs e)
        {
            FiltredPayments = null;
            item = (PaymentHuman)PaymentHumanListView.SelectedValue;
            FiltredPayments = FiltrPay(item);
            PhoneNumberTextBlock.Text = item.PhoneNumber.ToString();
            NameTextBlock.Text = item.Name.ToString();
            DiscriptionTextBLock.Text = item.Discript.ToString();
            ApartemetsTextBlock.Text = item.IdApartamentNavigation.Number.ToString();
            HomeTextBlock.Text = item.IdApartamentNavigation.IdBuildingNavigation.NumberBuilding.ToString();
        }


        public List<Payment> FiltrPay(PaymentHuman item)
        {

            List<Payment> list = new List<Payment>();
            list = AllPaymens.Where(x => x.IdHuman == item.Id).ToList();
            return list;
        }

        private void MouseDubleClick_PaymetsListView(object sender, MouseButtonEventArgs e)
        {

        }
        public double sum1 = 0;
        public double sum2 = 0;
        public double sum3 = 0;
        public double AllAmount;
        private void SummCLickBtn(object sender, RoutedEventArgs e)
        {
            sum1 = 0;
            sum2 = 0;
            sum3 = 0;
            AllAmount = 0;
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

            AllAmount = sum1 + sum2 + sum3;
            TextBLockCountItog.Text = AllAmount.ToString();
            double[] billAgrs = new double[8];
            billAgrs = BilletCounter.BillCounts(AllAmount); // Возарвщает масив от где 0 элемент это 5000 купюры а 50 - 6 элемент  а 7 элемент это остаток монет
            TBBill5k.Text = ((int)billAgrs[0]).ToString();
            TBBlii2k.Text = ((int)billAgrs[1]).ToString();
            TBBill1k.Text = ((int)billAgrs[2]).ToString();
            TBBill500.Text = ((int)billAgrs[3]).ToString();
            TBBill200.Text = ((int)billAgrs[4]).ToString();
            TBBill100.Text = ((int)billAgrs[5]).ToString();
            TBBill50.Text = ((int)billAgrs[6]).ToString();
            TBOSt.Text = Math.Round(billAgrs[7],2).ToString();
        }
        private void DragMove_MousedounLogo(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        public static async void AddNewPayments(Payment paymentCount)
        {
            await HttpRequest.PostAsync<bool>($"{adress}Home/addNewPayments", paymentCount);
        } 
        private void SaveDataBtn_click(object sender, RoutedEventArgs e)
        {
            if(AllAmount== 0){
                MessageBox.Show("Выплатта не расичтана");
            }
            else {        
            Payment paymentCount = new Payment()
            {
                IdHuman = item.Id,
                Amount1 = ((decimal)sum1),
                Amount2 = ((decimal)sum2),
                Amount3 = ((decimal)sum3),
                CountAmount = ((decimal)AllAmount),
                CountBillTire1 = Convert.ToInt32(TBBill5k.Text),
                CountBillTire2 = Convert.ToInt32(TBBlii2k.Text),
                CountBillTire3 = Convert.ToInt32(TBBill1k.Text),
                CountBillTire4 = Convert.ToInt32(TBBill500.Text),
                CountBillTire5 = Convert.ToInt32(TBBill200.Text),
                CountBillTire6 = Convert.ToInt32(TBBill100.Text),
                CountBillTire7 = Convert.ToInt32(TBBill50.Text),
                CountCoins = Convert.ToInt32(TBOSt.Text),
                Date  = DateTime.Now,
            };
            AddNewPayments(paymentCount);
            }
        }

        private void AddNewObjBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteImage_MouseDouwn(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
