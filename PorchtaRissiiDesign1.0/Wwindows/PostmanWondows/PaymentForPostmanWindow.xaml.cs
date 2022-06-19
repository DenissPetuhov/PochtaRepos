using PorchaAPI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static PorchtaRissiiDesign1._0.App;

namespace PorchtaRissiiDesign1._0.Wwindows.PostmanWondows
{
    /// <summary>
    /// Логика взаимодействия для PaymentForPostmanWindow.xaml
    /// </summary>
    public partial class PaymentForPostmanWindow : Window, INotifyPropertyChanged
    {
        public PaymentForPostmanWindow(User user)
        {
            UserCatualitu = user;
            InitializeComponent();
            UpdateDate();
        }

        public async void UpdateDate()
        {
            Payments = await HttpRequest.GetAsync<List<Payment>>($"{adress}Home/Payments");
            Payments = Payments.Where(x => x.IdHumanNavigation.IdApartamentNavigation.IdBuildingNavigation.IdRegionNavigation.RegionId == UserCatualitu.IdRegion).ToList();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
        private User _user;
        public User UserCatualitu
        {
            get { return _user; }
            set { _user = value; }
        }
        private List<Payment> payments;
        public List<Payment> Payments
        {
            get { return payments; }
            set { payments = value; OnPropertyChanged(); }
        }
        private ObservableCollection<Payment> selectedPayments = new ObservableCollection<Payment>();

        public ObservableCollection<Payment> SelectedPayments
        {
            get { return selectedPayments; }
            set { selectedPayments = value; OnPropertyChanged(); }
        }
        private decimal countCoins;

        public decimal CountCoins
        {
            get { return countCoins; }
            set { countCoins = value; OnPropertyChanged(); }
        }
        private int bill5k;

        public int Bill5k
        {
            get { return bill5k; }
            set { bill5k = value; OnPropertyChanged(); }
        }

        private int bill2k;

        public int Bill2k
        {
            get { return bill2k; }
            set { bill2k = value; OnPropertyChanged(); }
        }
        private int bill1k;

        public int Bill1k
        {
            get { return bill1k; }
            set { bill1k = value; OnPropertyChanged(); }
        }
        private int bill500;

        public int Bill500
        {
            get { return bill500; }
            set { bill500 = value; OnPropertyChanged(); }
        }

        private int bill200;

        public int Bill200
        {
            get { return bill200; }
            set { bill200 = value; OnPropertyChanged(); }
        }

        private int bill100;

        public int Bill100
        {
            get { return bill100; }
            set { bill100 = value; OnPropertyChanged(); }
        }

        private int bill50;

        public int Bill50
        {
            get { return bill50; }
            set { bill50 = value; OnPropertyChanged(); }
        }
        private decimal ost;

        public decimal Ost
        {
            get { return ost; }
            set { ost = value; OnPropertyChanged(); }
        }


        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void DragMove_MousedounLogo(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void MouseDubleClick_SelectedPaymetsListView(object sender, MouseButtonEventArgs e)
        {
            Payment item = (Payment)PaymentListView.SelectedItem;
            SelectedPayments.Remove(item);
        }

        private void MouseDoubleCLikPaymaent(object sender, MouseButtonEventArgs e)
        {

            Payment item = (Payment)PaymentListView.SelectedValue;
            SelectedPayments.Add(item);
            if (item == null)
            {

            }else if(item !=null)
            foreach (Payment pay in selectedPayments)
            {
                CountCoins += (decimal)pay.CountAmount;
                Bill5k += (int)pay.CountBillTire1;
                Bill2k += (int)pay.CountBillTire2;
                Bill1k += (int)pay.CountBillTire3;
                Bill500 += (int)pay.CountBillTire4;
                Bill200 += (int)pay.CountBillTire5;
                Bill100 += (int)pay.CountBillTire6;
                Bill50 += (int)pay.CountBillTire7;
                Ost += (decimal)pay.CountCoins;
                TBBill5k.Text = Bill5k.ToString();
                TBBlii2k.Text = Bill2k.ToString();
                TBBill1k.Text = Bill1k.ToString();
                TBBill500.Text = Bill500.ToString();
                TBBill200.Text = Bill200.ToString();
                TBBill100.Text = Bill100.ToString();
                TBBill50.Text = Bill50.ToString();
                TBOSt.Text = Ost.ToString();
                TextBLockCountItog.Text = CountCoins.ToString();
            }
        }

        private void Update_Refreshbutton(object sender, RoutedEventArgs e)
        {
            Bill5k = 0;
            Bill2k = 0;
            Bill1k = 0;
            Bill500 = 0;
            Bill200 = 0;
            Bill100 = 0;
            Bill50 = 0;
            Ost = 0;
            CountCoins = 0;
            TBBill5k.Text = Bill5k.ToString();
            TBBlii2k.Text = Bill2k.ToString();
            TBBill1k.Text = Bill1k.ToString();
            TBBill500.Text = Bill500.ToString();
            TBBill200.Text = Bill200.ToString();
            TBBill100.Text = Bill100.ToString();
            TBBill50.Text = Bill50.ToString();
            TBOSt.Text = Ost.ToString();
            TextBLockCountItog.Text = CountCoins.ToString();
        }
    }

}
