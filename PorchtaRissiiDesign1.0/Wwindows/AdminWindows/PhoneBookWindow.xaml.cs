using PorchaAPI;
using PorchtaRissiiDesign1._0.Wwindows.PageRedakt;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using static PorchtaRissiiDesign1._0.App;

namespace PorchtaRissiiDesign1._0.Wwindows.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для PhoneBook.xaml
    /// </summary>
    public partial class PhoneBookWindow : Window, INotifyPropertyChanged
    {
        public PhoneBookWindow()
        {
            
            InitializeComponent();
            UpdateDate();
        }
        public async void UpdateDate()
        {
            var list = await HttpRequest.GetAsync<List<PhoneBook>>($"{adress}Home/PhoneBook");
            PhoneBooks = new ObservableCollection<PhoneBook>(list);
        }
        private ObservableCollection<PhoneBook> phoneBooks { get; set; }
        
        public ObservableCollection<PhoneBook> PhoneBooks { get => phoneBooks; set { phoneBooks = value; OnPropertyChanged(); } } 
   
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

        private void DragMove_MousedounLogo(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }


        private async void DeleteImage_MouseDouwn(object sender, MouseButtonEventArgs e)
        {
            var PB = (PhoneBook)ListViewPhoneBook.SelectedValue;

            if(PB != null)
            {
                try
                {
                    await HttpRequest.DeleteAsync<PhoneBook>($"{adress}Home/DeletePhone.id={PB.Id}");
                    PhoneBooks.Remove(PB);
                }
                catch (Exception )
                {
                    MessageBox.Show("Не кдалось удалить что то");
                }

            }
            else
            {
                MessageBox.Show("Выберите обьект");
            }


        }

        private void AddNewObjBorder_MouseDown(object sender, MouseButtonEventArgs e)
        {
            AddNewPBPage page  = new AddNewPBPage();
            RedaktWindow RW = new RedaktWindow(page);
            RW.Show();

        }
    }
}
