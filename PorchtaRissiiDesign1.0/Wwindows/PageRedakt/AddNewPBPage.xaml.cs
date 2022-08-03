using PorchaAPI;
using System.Windows;
using System.Windows.Controls;
using static PochtaRossiiDesign1._0.App;

namespace PochtaRossiiDesign1._0.Wwindows.PageRedakt
{
    /// <summary>
    /// Логика взаимодействия для AddNewPBPage.xaml
    /// </summary>
    public partial class AddNewPBPage : Page
    {
        public AddNewPBPage()
        {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            PhoneBook objPB = new PhoneBook()
            {
                NameOrganisation = TBoxNameOrganism.Text,
                Phone1 = TBoxPhone1.Text,
                Phone2 = TBoxPhone2.Text,
                Phone3 = TBoxPhone3.Text,
                Address = TBoxAdress.Text,
                Discript = TBoxDiscript.Text,

            };
         
                await HttpRequest.PostAsync<PhoneBook>($"{adress}Home/AddNewPhoneBook", objPB);

        
           
        }
    }
}
