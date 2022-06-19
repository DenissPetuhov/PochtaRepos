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
using static PorchtaRissiiDesign1._0.App;

namespace PorchtaRissiiDesign1._0.Wwindows.AdminWindows
{
    /// <summary>
    /// Логика взаимодействия для CreateAndRedactRegionWindow.xaml
    /// </summary>
    public partial class CreateAndRedactRegionWindow : Window
    {
        public CreateAndRedactRegionWindow()
        {
            InitializeComponent();
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
    }
}
