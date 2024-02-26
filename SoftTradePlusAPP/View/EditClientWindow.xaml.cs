using SoftTradePlusAPP.Model;
using SoftTradePlusAPP.ViewModel;
using System.Windows;


namespace SoftTradePlusAPP.View
{
    /// <summary>
    /// Логика взаимодействия для AddNewClientWindow.xaml
    /// </summary>
    public partial class EditClientWindow : Window
    {
        public EditClientWindow(Client clientToEdit)
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            DataManagerVM.SelectedClientLine = clientToEdit;
            DataManagerVM.ClientName = clientToEdit.Name;
            DataManagerVM.ClientManager = clientToEdit.Manager;
            


        }
    }
}
