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
    /// Логика взаимодействия для PostmanMenuWindow.xaml
    /// </summary>
    public partial class PostmanMenuWindow : Window, INotifyPropertyChanged
    {
        public PostmanMenuWindow(User user)
        {
            Postman = user;
            InitializeComponent();

            UpdateDate();
        }
        public async void UpdateDate()
        {
            try
            {
                Tasks = await HttpRequest.GetAsync<List<PorchaAPI.Task>>($"{adress}Home/Task");
                Tasks = Tasks.Where(x => x.IdPostman == Postman.Id).ToList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private User postman;

        public User Postman
        {
            get { return postman; }
            set { postman = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        private List<PorchaAPI.Task> task;
        public List<PorchaAPI.Task> Tasks
        {
            get { return task; }
            set { task = value; OnPropertyChanged(); }
        }

       
        private void DragMove_MousedounLogo(object sender, MouseButtonEventArgs e)
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

        private void BIldingsIcons_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BildingsForAdminWindow BFA = new BildingsForAdminWindow(Postman);
            BFA.Show();
        }

        private void TBlockReLoginAdmin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }

        private void CLick_PaymentHumanIcon(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
