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
    /// Логика взаимодействия для AddNewProductWindow.xaml
    /// </summary>
    public partial class EditProductWindow : Window
    {
        public EditProductWindow(Product productToEdit)
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            DataManagerVM.SelectedProductLine = productToEdit;
            DataManagerVM.ProductName = productToEdit.Name;
            DataManagerVM.ProductPrice = productToEdit.Price;
            DataManagerVM.ProductType = productToEdit.Type;
            DataManagerVM.ProductSubscriptionPeriod = productToEdit.SubscriptionPeriod;
        }
    }
}
