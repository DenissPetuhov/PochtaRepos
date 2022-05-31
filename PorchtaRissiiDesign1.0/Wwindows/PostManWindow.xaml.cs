
using PorchaAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using static PorchtaRissiiDesign1._0.App;


namespace PorchtaRissiiDesign1._0.Wwindows
{
    /// <summary>
    /// Логика взаимодействия для PostmanWindow.xaml
    /// </summary>
    public partial class PostmanWindow : Window , INotifyPropertyChanged
    {
        public PostmanWindow()
        {
            InitializeComponent();
               UpdateDate();
        Url = "https://2gis.ru/smolensk/geo/8867123191349253?m=32.021983%2C54.809628%2F16";
           
        }

        private List<Building> _buildings;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<Building> Buildings { get => _buildings; set { _buildings = value; OnPropertyChanged(); } }

        public List<Building> AllBuildings { get; set; }


        private List<PaymentHuman> _paymentHuman;
        public List<PaymentHuman> paymentHumen { get => _paymentHuman; set { _paymentHuman = value; OnPropertyChanged(); } }

        public async void UpdateDate()
        {
            AllBuildings =await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
            Buildings = AllBuildings;
            paymentHumen = await HttpRequest.GetAsync<List<PaymentHuman>>($"{adress}Home/PaymentHumans");
        }


        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        public string Url { get => _url; set { _url = value; } }
        private string _url { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WebView.Source = new Uri("https://2gis.ru/smolensk/geo/8867123191349253?m=32.021983%2C54.809628%2F16");

        }
    }
}

