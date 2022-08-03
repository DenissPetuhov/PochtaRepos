using PochtaRossiiDesign1._0.Wwindows.PageRedakt;
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

namespace PochtaRossiiDesign1._0.Wwindows
{
    /// <summary>
    /// Логика взаимодействия для RedaktWindow.xaml
    /// </summary>
    public partial class RedaktWindow : Window
    {
        public RedaktWindow(Page page)
        {
            InitializeComponent(); 
            FrameRedaktWindowNavigate.Navigate(page);
        }

        private void MinimizeImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseImage_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
