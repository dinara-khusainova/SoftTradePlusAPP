using SoftTradePlusAPP.ViewModel;
using System.Windows;


namespace SoftTradePlusAPP.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewProductWindow.xaml
    /// </summary>
    public partial class AddNewProductWindow : Window
    {
        public AddNewProductWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
        }
    }
}
