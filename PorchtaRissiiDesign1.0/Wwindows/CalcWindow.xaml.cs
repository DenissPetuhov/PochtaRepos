using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для CalcWindow.xaml
    /// </summary>
    public partial class CalcWindow : Window
    {
        public CalcWindow()
        {
            InitializeComponent();
            foreach (UIElement element in MainGrid.Children)
            {
                if (element is Button)
                {
                   // ((Button)element).Click += Button_Click;

                }

            }
            // private void Button_Click(object sender, RoutedEventArgs e)
            //{
            //    string str = (string)((Button)e.OriginalSource).Content;
            //    if (str == "Clear")
            //        TextBox1.Text = "";
            //    else if (str == "=")
            //    {
            //        try
            //        {
            //            string value = new DataTable().Compute(TextBox1.Text, null).ToString();
            //            TextBox1.Text = value;
            //        }
            //        catch (SyntaxErrorException)
            //        {
            //            MessageBox.Show("Неправильное уровнение ", "Ошибка!");
            //        }
            //        catch (EvaluateException)
            //        {
            //            MessageBox.Show("В поле имеется текст!", "Ошибка!");
            //        }
            //    }

            //    else
            //        TextBox1.Text += str;

            //}

        }
    }
}
