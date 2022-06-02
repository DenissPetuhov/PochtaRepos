using PorchaAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static PorchtaRissiiDesign1._0.App;

namespace PorchtaRissiiDesign1._0.Wwindows.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для TasksWindow.xaml
    /// </summary>
    public partial class TasksWindow : Window, INotifyPropertyChanged
    {
        public TasksWindow(User postman)
        {
            Postman = postman;
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
        public User Postman { get; }
        private List<PorchaAPI.Task> tasks { get; set; }
        public List<PorchaAPI.Task> Tasks { get => tasks; set { tasks = value; OnPropertyChanged(); } }

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
        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void TBlockTaskText_Click(object sender, RoutedEventArgs e)
        {
            var content = ((Button)sender).DataContext as PorchaAPI.Task;
            content.TextBoxVisibility = Visibility.Visible;
        }
        private async void ConfirmRedactTextBox(object sender, MouseButtonEventArgs e)
        {
            var content = ((Image)sender).DataContext as PorchaAPI.Task;
            var response = await HttpRequest.PutAsync<bool>($"{adress}Home/ChangeTask", content);

            if (!response)
            {
                return;
            }

            content.TextBoxVisibility = Visibility.Collapsed;
        }
        private void CanselIconTextBox(object sender, MouseButtonEventArgs e)
        {
            var content = ((Image)sender).DataContext as PorchaAPI.Task;
            content.TextBoxVisibility = Visibility.Collapsed;
        }
    }
}
