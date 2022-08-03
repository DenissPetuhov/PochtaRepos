using System;
using System.Windows;
using System.Windows.Input;
using PorchaAPI;
using PochtaRossiiDesign1._0.Utils;
using PochtaRossiiDesign1._0.Wwindows;
using PochtaRossiiDesign1._0.Wwindows.AdminWindows;
using PochtaRossiiDesign1._0.Wwindows.PostmanWondows;
using static PochtaRossiiDesign1._0.App;

namespace PochtaRossiiDesign1._0.AutorisationAndRegistrWindow
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

        }
        private static UserCredentialValidator credantialValidator = new UserCredentialValidator();
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

        private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (TextBoxPassword.Password.Length > 0)
            {
                TextBlockPassword.Visibility = Visibility.Collapsed;
            }
            else
            {
                TextBlockPassword.Visibility = Visibility.Visible;
            }
        }

    


        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string errorMessage = credantialValidator.validateLogin(TextBoxLogin.Text, TextBoxPassword.Password);

            if (errorMessage.Length == 0)
            {
                try
                {
                    // Вынести в DAO, почитать как релизовать DAO, А так же MVVM
                    var user = await HttpRequest.GetAsync<User>($"{adress}Home/Login.login={TextBoxLogin.Text}.password={TextBoxPassword.Password}");
                    if (user == null)
                    {
                        MessageBox.Show("Пользователь не найден, проверьте логин или пароль", "Ошибка");
                    }
                    else
                    {
                        switch (user.IdRole)
                        {
                            //Принцип ООП ИЗУЧИТЬ
                            case 1:
                                MessageBox.Show("Добрый день почтальон " + user.Name + "!", "Уведомление!");
                                PostmanMenuWindow postmanWindow = new PostmanMenuWindow(user);
                                postmanWindow.Show();
                                this.Close();
                                break;
                            case 2:
                                MessageBox.Show("Добрый день Администротор " + user.Name + "!", "Уведомление!");
                                AdminWindow adminWindow = new AdminWindow(user);
                                adminWindow.Show();
                                this.Close();
                                break;
                                //почитать про систему логирования

                        }


                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка" + ex.Message.ToString() + "Критическая ошибка!",
                        "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }

            else
            {
                MessageBox.Show(errorMessage, "Ошика!");
            }
        }

    }

}








