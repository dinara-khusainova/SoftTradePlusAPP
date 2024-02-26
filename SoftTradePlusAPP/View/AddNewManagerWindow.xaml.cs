using SoftTradePlusAPP.Model;
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
using SoftTradePlusAPP.ViewModel;

namespace SoftTradePlusAPP.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewManagerWindow.xaml
    /// </summary>
    public partial class AddNewManagerWindow : Window
    {
        public AddNewManagerWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
        }
    }
}
