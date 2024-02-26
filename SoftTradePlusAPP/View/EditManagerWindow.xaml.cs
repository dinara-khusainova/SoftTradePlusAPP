using SoftTradePlusAPP.Model;
using SoftTradePlusAPP.ViewModel;
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

namespace SoftTradePlusAPP.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewManagerWindow.xaml
    /// </summary>
    public partial class EditManagerWindow : Window
    {
        public EditManagerWindow(Manager managerToEdit)
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            DataManagerVM.SelectedManagerLine = managerToEdit;
        }
    }
}
