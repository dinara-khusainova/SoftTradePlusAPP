using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoftTradePlusAPP.Model;
using SoftTradePlusAPP.View;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SoftTradePlusAPP.View
{
    /// <summary>
    /// Логика взаимодействия для ShowMessageWindow.xaml
    /// </summary>
    public partial class ShowMessageWindow : Window
    {
        public ShowMessageWindow(string text)
        {
            InitializeComponent();
            MessageText.Text = text;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
