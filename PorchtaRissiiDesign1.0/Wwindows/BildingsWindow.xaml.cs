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
using static PochtaRossiiDesign1._0.App;


namespace PochtaRossiiDesign1._0.Wwindows
{
    /// <summary>
    /// Логика взаимодействия для BildingsForAdminWindow.xaml
    /// </summary>
    public partial class BildingsWindow : Window, INotifyPropertyChanged
    {
        private int selectedSort;
        public int SelectedSort 
        {
            get => selectedSort;
            set
            {
                selectedSort = value;
                OnPropertyChanged();
                SortNumber();
            }
        }
        public BildingsWindow(User user)
        {
            Useres = user;
            InitializeComponent();
            if (Useres.IdRole == 1)
            {
                CboxFiltrHomes.Visibility = Visibility.Collapsed;
                TBlockFiltrHomes.Visibility = Visibility.Collapsed;
             
            }
            UpdateDate();
        }

        private void SortNumber()
        {
            if (Apartments == null)
            {
                MessageBox.Show("выберите дом!");
            }
            else
            {

                if (SelectedSort == 0)
                {
                    Apartments = Apartments.OrderBy(x => x.Number).ToList();
                }
                if (SelectedSort == 1)
                {
                    Apartments = Apartments.OrderByDescending(x => x.Number).ToList();
                }
            }
          
          
        }

        public async void UpdateDate()
        {
            if(Useres.IdRole == 1)
            {
                Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
                Buildings = Buildings.Where(x => x.IdRegion==Useres.IdRegion).ToList();

              

            }
            else if(Useres.IdRole == 2)
            {
                Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
            }
           
           
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
        Building SelectedBuiding;
        private async void DubleclickBuinding_ListView(object sender, MouseButtonEventArgs e)
        {
            Apartments = null;
             SelectedBuiding = (Building)BuildingListView.SelectedValue;

                Apartments = await HttpRequest.GetAsync<List<Apartment>>($"{adress}Home/Apartaments.id={SelectedBuiding.BuildingId}");

            Uri uri = new Uri(SelectedBuiding.Url2Gis);//Создание ссылки для вебвью
            WebView.Source = uri;
            tblockBuildingNUmber.Text = SelectedBuiding.NumberBuilding;//заполнение бордера 
            tblockCountDoorway.Text = SelectedBuiding.DoorwayCount.ToString();

        }

        private async void CboxFiltrHomes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");
            int index = CboxFiltrHomes.SelectedIndex + 1;
            if (index != 4)
                Buildings = Buildings.Where(x => x.IdRegion == index).ToList();
            else if(index == 4)
                Buildings = await HttpRequest.GetAsync<List<Building>>($"{adress}Home/Buildings");




        }

        private async void StatusBox_SelectChanged(object sender, SelectionChangedEventArgs e)
        {
            int status =new int();
          if(CBoxStatus.SelectedIndex == 0)
            {
                status = 1;

            }else if(CBoxStatus.SelectedIndex == 1)
            {
                status = 2;
            }
            else if (CBoxStatus.SelectedIndex == 2)
            {
                status = 3;
            }
            else if (CBoxStatus.SelectedIndex == 3)
            {
                status = 4;
            }
            Apartment aptsss = new Apartment
            {   ApartmentId = apsses.ApartmentId,
                IdBuilding = apsses.IdBuilding,
                Discript = apsses.Discript,
                Number = apsses.Number,
                PaymentHumans = apsses.PaymentHumans,
                VilagerName = apsses.VilagerName,
                IdPhoto = apsses.IdPhoto,
                IdStatusBox = status,
            };
            try
            {
                await HttpRequest.PutAsync<bool>($"{adress}Home/UpdateApartaments", aptsss);

            }
            catch (Exception)
            {

                throw;
            }


                Apartments = await HttpRequest.GetAsync<List<Apartment>>($"{adress}Home/Apartaments.id={SelectedBuiding.BuildingId}");
            
        }
        Apartment apsses = new Apartment();
        private void ListViewApartament_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var apss = (Apartment)ListViewApartaments.SelectedValue;
            TbStatusBox.Text = apss.IdStatusBoxNavigation.Status;
            apsses = apss;

        }
    }
}
