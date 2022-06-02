using PorchaAPI;
using PorchtaRissiiDesign1._0.AutorisationAndRegistrWindow;
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
    /// Логика взаимодействия для AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window, INotifyPropertyChanged
    {
        public AdminWindow(User user)
        {
            Useres = user;
            DataUpdate();
            InitializeComponent();

        }
        private User useres;

        public User Useres
        {
            get { return useres; }
            set { useres = value; }
        }
        private async void DataUpdate()
        {
            AllUsers = await HttpRequest.GetAsync<List<User>>($"{adress}Home/Users");
            Userses = AllUsers;
            Postmans = Userses.Where(x => x.IdRole == 1).ToList();
        }
        private List<User> _users = new List<User>();
        public List<User> Userses { get => _users; set { _users = value; OnPropertyChanged(); } }
        public List<User> AllUsers { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string s = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }
        private List<User> _postmans;
        public List<User> Postmans { get => _postmans; set { _postmans = value; OnPropertyChanged(); } }
        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void TBlockReLoginAdmin_MouseDown(object sender, MouseButtonEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            this.Close();
            loginWindow.Show();
        }

        private void DragMove_MousedounLogo(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void BtnGiveTask(object sender, RoutedEventArgs e)
        {
            var parameter = ((Button)sender).DataContext;
            if (parameter is User postman)
            {
                var window = new TasksWindow(postman);
                window.Show();
            }
        }

        private void Click_PhoneBookIcon(object sender, MouseButtonEventArgs e)
        {
            PhoneBookWindow PB = new PhoneBookWindow();
            PB.Show();
        }

        private void CLick_PaymentHumanIcon(object sender, MouseButtonEventArgs e)
        {
            PayMentWindow PW = new PayMentWindow();
            PW.Show();
           
        }

        private void BIldingsIcons_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BildingsWindow BFA = new BildingsWindow(Useres);
            BFA.Show();
        }
    }
}
