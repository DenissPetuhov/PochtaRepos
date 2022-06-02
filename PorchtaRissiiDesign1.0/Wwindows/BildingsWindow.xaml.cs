using PorchaAPI;
using System;
using System.Collections.Generic;
using System.Linq;
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


namespace PorchtaRissiiDesign1._0.Wwindows
{
    /// <summary>
    /// Логика взаимодействия для BildingsForAdminWindow.xaml
    /// </summary>
    public partial class BildingsWindow : Window
    {
        public BildingsWindow(User user)
        {
            Useres = user;
            InitializeComponent();
            if (Useres.IdRole == 1)
            {
                CboxFiltrHomes.Visibility = Visibility.Collapsed;
                TBlockFiltrHomes.Visibility= Visibility.Collapsed;
                RedacktHomesStackPanel.Visibility = Visibility.Collapsed;
                RedacktApartStackPanel.Visibility = Visibility.Collapsed;
            }
        }
     
        private User useres;

        public User Useres
        {
            get { return useres; }
            set { useres = value; }
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
    }
}
