
using SoftTradePlusAPP.ViewModel;
using System.Windows;
using System.Windows.Controls;


namespace SoftTradePlusAPP
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllManagersView;
        public static ListView AllClientsView;
        public static ListView AllProductsView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();

            AllManagersView = ViewAllManagers;
            AllClientsView = ViewAllClients;
            AllProductsView = ViewAllProducts;
        }
       
    }
}
