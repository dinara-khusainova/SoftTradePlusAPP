using SoftTradePlusAPP.ViewModel;
using System.Windows;

namespace SoftTradePlusAPP.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class AddNewClientWindow : Window
    {
        public AddNewClientWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
        }
    }
}
