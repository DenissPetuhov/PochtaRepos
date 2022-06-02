using System;
using System.Windows;
using System.Windows.Input;
using PorchaAPI;
using PorchtaRissiiDesign1._0.Utils;
using static PorchtaRissiiDesign1._0.App;

namespace PorchtaRissiiDesign1._0.AutorisationAndRegistrWindow
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
        {
            InitializeComponent();

        }
        private static UserCredentialValidator credantialValidator = new UserCredentialValidator();

        LoginWindow login = new LoginWindow();
        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
        private void BackBlockCLick(object sender, MouseButtonEventArgs e)
        {
            login.Show();
            this.Close();
        }
        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Password.Length > 0)
                TextBlockPassword.Visibility = Visibility.Collapsed;
            else
                TextBlockPassword.Visibility = Visibility.Visible;
        }
        private void ReapeatPaswordChanget(object sender, RoutedEventArgs e)
        {
            if (TextBoxPasswordRep.Password.Length > 0)
                TextBlockPasswordRep.Visibility = Visibility.Collapsed;
            else
                TextBlockPasswordRep.Visibility = Visibility.Visible;
        }
        private async void BtnRegistration(object sender, RoutedEventArgs e)
        {
            string errorMessage = credantialValidator.validateRegist(TextBoxLogin.Text, TextBoxPassword.Password, TextBoxPasswordRep.Password, TextBoxName.Text);

            if (errorMessage.Length == 0)
            {

                try
                {
                    User userOjb = new User()
                    {
                        Name = TextBoxName.Text,
                        Password = TextBoxPassword.Password,
                        Login = TextBoxLogin.Text,
                        IdRole = 1,
                    };
                    await HttpRequest.PostAsync<User>($"{adress}Home/PostUser", userOjb);
                    
                    MessageBox.Show("Пользователь " + userOjb.Name + " успешно зарегистрирован!");
                    LoginWindow login = new LoginWindow();
                    login.Show();
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!");
                }
            }
            else
            {
                MessageBox.Show(errorMessage, "Ошибка!");
            }
        }
    }

}

