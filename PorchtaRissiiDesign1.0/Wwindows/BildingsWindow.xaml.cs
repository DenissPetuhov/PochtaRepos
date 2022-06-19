using PorchaAPI;
using System;
using System.Collections.Generic;
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


namespace PorchtaRissiiDesign1._0.Wwindows
{
    /// <summary>
    /// Логика взаимодействия для BildingsForAdminWindow.xaml
    /// </summary>
    public partial class BildingsWindow : Window, INotifyPropertyChanged
    {
        public BildingsWindow(User user)
        {
            Useres = user;
            InitializeComponent();
            if (Useres.IdRole == 1)
            {
                CboxFiltrHomes.Visibility = Visibility.Collapsed;
                TBlockFiltrHomes.Visibility = Visibility.Collapsed;
                RedacktHomesStackPanel.Visibility = Visibility.Collapsed;
                RedacktApartStackPanel.Visibility = Visibility.Collapsed;
            }
            UpdateDate();
        }

        public async void UpdateDate()
        {
            if(Useres.IdRole == 1)
            {
                Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
                Buildings = Buildings.Where(x => x.IdRegion==Useres.IdRegion).ToList();
                Apartments = await HttpRequest.GetAsync<List<Apartment>>($"{adress}Home/Apartaments");
                Apartments = Apartments.Where(x => x.IdBuildingNavigation.IdRegion == Useres.IdRegion).ToList();

            }
            else if(Useres.IdRole == 2)
            {
                Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
            }
           
            Apartments = await HttpRequest.GetAsync<List<Apartment>>($"{adress}Home/Apartaments");
        }
        private User useres;

        public User Useres
        {
            get { return useres; }
            set { useres = value; }
        }

        private List<Building> buildings;

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        public List<Building> Buildings
        {
            get { return buildings; }
            set { buildings = value; OnPropertyChanged(); }
        }


        private List<Apartment> apartments;

        public List<Apartment> Apartments
        {
            get { return apartments; }
            set { apartments = value; OnPropertyChanged(); }
        }
        private List<Apartment> filapp;

        public List<Apartment> Fillapp
        {
            get { return filapp; }
            set { filapp = value; OnPropertyChanged(); }
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



        private void AddNewHomeObjBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void AddNewApartObjBorder_MouseDown2(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteHomeImage_MouseDouwn(object sender, MouseButtonEventArgs e)
        {

        }

        private void DeleteApartImage_MouseDouwn2(object sender, MouseButtonEventArgs e)
        {

        }

        private async void DubleclickBuinding_ListView(object sender, MouseButtonEventArgs e)
        {
            Apartments = await HttpRequest.GetAsync<List<Apartment>>($"{adress}Home/Apartaments");
            var item = (Building)BuildingListView.SelectedValue;
            Apartments = Apartments.Where(x => x.IdBuilding == item.BuildingId).ToList();// заполнение квартр по фильтру дома
            Uri uri = new Uri(item.Url2Gis);//Создание ссылки для вебвью
            WebView.Source = uri;
            tblockBuildingNUmber.Text = item.NumberBuilding;//заполнение бордера 
            tblockCountDoorway.Text = item.DoorwayCount.ToString();

        }

        private async void CboxFiltrHomes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
            int index = CboxFiltrHomes.SelectedIndex + 1;
            Buildings = Buildings.Where(x => x.IdRegion == index).ToList();

        }
    }
}
