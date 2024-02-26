using SoftTradePlusAPP.Model;
using SoftTradePlusAPP.View;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace SoftTradePlusAPP.ViewModel
{
    public class DataManagerVM : INotifyPropertyChanged
    {
        private List<Manager> allManagers = DataManipulator.ListOfManagers();
        public List<Manager> AllManagers
        {
            get { return allManagers; }
            set
            {
                allManagers = value;
                NotifyPropertyChanged("AllManagers");


            }
        }

        private List<Client> allClients = DataManipulator.ListOfClients();
        public List<Client> AllClients
        {
            get { return allClients; }
            set
            {
                allClients = value;
                NotifyPropertyChanged("AllClients");


            }
        }
        private List<Product> allProducts = DataManipulator.ListOfProducts();
        public List<Product> AllProducts
        {
            get { return allProducts; }
            set
            {
                allProducts = value;
                NotifyPropertyChanged("AllProducts");


            }
        }

        // Manager:
        public static string ManagerName { get; set; }
        // Client:
        public static string ClientName { get; set; }
        
        public static Manager ClientManager { get; set; }
        
        // Product:
        public static string ProductName { get; set; }
        public static decimal ProductPrice { get; set; }

        public static SubscriptionType ProductType { get; set; }
        public static SubscriptionPeriod ProductSubscriptionPeriod { get; set; }


        // list OF CLIENTS BY MANAGERS:

        private Manager selectedManager;
        public Manager SelectedManager
        {
            get { return selectedManager; }
            set
            {
                selectedManager = value;
                NotifyPropertyChanged(nameof(SelectedManager));
                UpdateClientsBySelectedManager(); 
            }
        }

        
        private List<Client> clientsBySelectedManager;
        public List<Client> ClientsBySelectedManager
        {
            get { return clientsBySelectedManager; }
            set
            {
                clientsBySelectedManager = value;
                NotifyPropertyChanged(nameof(ClientsBySelectedManager));
            }
        }

        private void UpdateClientsBySelectedManager()
        {
            if (SelectedManager != null)
            {
                ClientsBySelectedManager = SelectedManager.Clients;
            }
            else
            {
                ClientsBySelectedManager = null;
            }
        }


        // list OF PRODUCTS BY CLIENTS:
        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                NotifyPropertyChanged(nameof(SelectedClient));
                UpdateProductsBySelectedClient(); 
            }
        }


        private List<Product> productsBySelectedClient;
        public List<Product> ProductsBySelectedClient
        {
            get { return productsBySelectedClient; }
            set
            {
                productsBySelectedClient = value;
                NotifyPropertyChanged(nameof(ProductsBySelectedClient));
            }
        }

        private void UpdateProductsBySelectedClient()
        {
            if (SelectedClient != null)
            {
                ProductsBySelectedClient = SelectedClient.PurchasedProducts;
            }
            else
            {
                ProductsBySelectedClient = null;
            }
        }

        // list OF CLIENTS BY STATUS:

        private ClientStatus selectedClientStatusFilter;
        public ClientStatus SelectedClientStatusFilter
        {
            get { return selectedClientStatusFilter; }

            set
            {
                if (selectedClientStatusFilter != value)
                {
                    selectedClientStatusFilter = value;
                    NotifyPropertyChanged(nameof(SelectedClientStatus));
                    UpdateClientsBySelectedClientStatus();

                }
            }
        }
        private List<Client> clientsBySelectedClientStatus;
        public List<Client> ClientsBySelectedClientStatus
        {
            get { return clientsBySelectedClientStatus; }
            set
            {
                clientsBySelectedClientStatus = value;
                NotifyPropertyChanged(nameof(ClientsBySelectedClientStatus));
            }
        }

        private void UpdateClientsBySelectedClientStatus()
        {
            ClientsBySelectedClientStatus = new List<Client>(AllClients.Where(c => c.Status == SelectedClientStatusFilter));
        }



        
        public Client ProductClient { get; set; }

        private SubscriptionType _selectedSubscriptionType;
        public SubscriptionType SelectedSubscriptionType
        {
            get { return _selectedSubscriptionType; }
            set
            {
                if (_selectedSubscriptionType != value)
                {
                    _selectedSubscriptionType = value;
                    NotifyPropertyChanged(nameof(SelectedSubscriptionType));
                }
            }
        }

        private ClientStatus _selectedClientStatus;

        public ClientStatus SelectedClientStatus
        {
            get { return _selectedClientStatus; }
            set
            {
                if (_selectedClientStatus != value)
                {
                    _selectedClientStatus = value;
                    NotifyPropertyChanged(nameof(SelectedClientStatus));
                }
            }
        }
        private SubscriptionPeriod _selectedSubscriptionPeriod;
        public SubscriptionPeriod SelectedSubscriptionPeriod
        {
            get { return _selectedSubscriptionPeriod; }
            set
            {
                if (_selectedSubscriptionPeriod != value)
                {
                    _selectedSubscriptionPeriod = value;
                    NotifyPropertyChanged(nameof(SelectedSubscriptionPeriod));
                }
            }
        }

        public TabItem SelectedTabItem { get; set; }
        public static Manager SelectedManagerLine { get; set; }
        public static Client SelectedClientLine { get; set; }
        public static Product SelectedProductLine { get; set; }



        private RelayCommand deleteItem;
        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Nothing is selected";
                    if (SelectedTabItem.Name == "ManagerTab" && SelectedManagerLine != null)
                    {
                        resultStr = DataManipulator.DeleteManager(SelectedManagerLine);
                        UpdateAllData();
                    }
                    if (SelectedTabItem.Name == "ClientTab" && SelectedClientLine != null)
                    {
                        resultStr = DataManipulator.DeleteClient(SelectedClientLine);
                        UpdateAllData();
                    }
                    if (SelectedTabItem.Name == "ProductTab" && SelectedProductLine != null)
                    {
                        resultStr = DataManipulator.DeleteProduct(SelectedProductLine);
                        UpdateAllData();
                    }
                    SetNullValues();
                    ShowMessage(resultStr);
                }
                
                );
            }
        }



        #region COMMANDS FOR ADDING ELEMENTS

        private RelayCommand addNewManager;
        public RelayCommand AddNewManager
        {
            get
            {
                return addNewManager ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";
                    if (ManagerName == null || ManagerName.Replace(" ", "").Length == 0)
                    {
                        SetRedLightBlock(window, "NameBlock");
                    }
                    else
                    {
                        resultStr = DataManipulator.CreateManager(ManagerName);
                        UpdateAllData();
                        ShowMessage(resultStr);
                        SetNullValues();
                        window.Close();
                    }
                });
            }
        }
        private RelayCommand addNewClient;
        public RelayCommand AddNewClient
        {
            get
            {
                return addNewClient ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";
                    if (ClientName == null || ClientName.Replace(" ", "").Length == 0)
                    {
                        SetRedLightBlock(window, "NameBlock");
                    }
                    
                    if (ClientManager == null)
                    {
                        ShowMessage("Input manager!");
                    }
                    else
                    {
                        resultStr = DataManipulator.CreateClient(ClientName, SelectedClientStatus, ClientManager);
                        UpdateAllData();
                        ShowMessage(resultStr);
                        SetNullValues();
                        window.Close();
                    }
                });
            }
        }


        private RelayCommand addNewProduct;
        public RelayCommand AddNewProduct
        {
            get
            {
                return addNewProduct ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "";
                    if (ProductName == null || ProductName.Replace(" ", "").Length == 0)
                    {
                        SetRedLightBlock(window, "NameBlock");
                    }
                    if (ProductPrice == 0)
                    {
                        SetRedLightBlock(window, "PriceBlock");
                    }
                    if (SelectedSubscriptionType == null)
                    {
                        ShowMessage("Select type!");
                    }
                    else
                    {
                        resultStr = DataManipulator.CreateProduct(ProductName, ProductPrice, SelectedSubscriptionPeriod, SelectedSubscriptionType, ProductClient);
                        UpdateAllData();
                        ShowMessage(resultStr);
                        SetNullValues();
                        window.Close();
                    }
                });
            }
        }
        #endregion
        #region UPDATE VIEWS
        private void SetNullValues()
        {

            ManagerName = null;

            ClientName = null;
            ClientManager = null;
            


            ProductName = null;
            ProductPrice = 0;
            ProductClient = null;


        }
        private void UpdateAllData()
        {
            UpdateAllManagersView();
            UpdateAllClientsView();
            UpdateAllProductsView();
        }

        private void UpdateAllManagersView()
        {
            AllManagers = DataManipulator.ListOfManagers();
            MainWindow.AllManagersView.ItemsSource = null;
            MainWindow.AllManagersView.Items.Clear();
            MainWindow.AllManagersView.ItemsSource = AllManagers;
            MainWindow.AllManagersView.Items.Refresh();
        }
        private void UpdateAllClientsView()
        {
            AllClients = DataManipulator.ListOfClients();
            MainWindow.AllClientsView.ItemsSource = null;
            MainWindow.AllClientsView.Items.Clear();
            MainWindow.AllClientsView.ItemsSource = AllClients;
            MainWindow.AllClientsView.Items.Refresh();
        }
        private void UpdateAllProductsView()
        {
            AllProducts = DataManipulator.ListOfProducts();
            MainWindow.AllProductsView.ItemsSource = null;
            MainWindow.AllProductsView.Items.Clear();
            MainWindow.AllProductsView.ItemsSource = AllProducts;
            MainWindow.AllProductsView.Items.Refresh();
        }


        #endregion

        #region COMMANDS FOR OPENING WINDOWS

        private RelayCommand openAddNewManagerWnd;
        public RelayCommand OpenAddNewManagerWnd
        {
            get
            {
                return openAddNewManagerWnd ?? new RelayCommand(obj =>
                {
                    OpenAddManagerWindowMethod();
                });
            }
        }
        private RelayCommand openAddNewClientWnd;
        public RelayCommand OpenAddNewClientWnd
        {
            get
            {
                return openAddNewClientWnd ?? new RelayCommand(obj =>
                {
                    OpenAddClientWindowMethod();
                });
            }
        }
        private RelayCommand openAddNewProductWnd;
        public RelayCommand OpenAddNewProductWnd
        {
            get
            {
                return openAddNewProductWnd ?? new RelayCommand(obj =>
                {
                    OpenAddProductWindowMethod();
                });
            }
        }

        private RelayCommand openEditItemWnd;
        public RelayCommand OpenEditItemWnd
        {
            get
            {
                return openEditItemWnd ?? new RelayCommand(obj =>
                {
                    string resultStr = "Nothing is selected";
                    if (SelectedTabItem.Name == "ManagerTab" && SelectedManagerLine != null)
                    {
                        OpenEditManagerWindowMethod(SelectedManagerLine);
                    }
                    if (SelectedTabItem.Name == "ClientTab" && SelectedClientLine != null)
                    {
                        OpenEditClientWindowMethod(SelectedClientLine);
                    }
                    if (SelectedTabItem.Name == "ProductTab" && SelectedProductLine != null)
                    {
                        OpenEditProductWindowMethod(SelectedProductLine);

                    }
                });
            }
        }

        #endregion

        #region METHODS FOR OPENING WINDOWS
        // methods of opening windows
        private void OpenAddManagerWindowMethod()
        {
            AddNewManagerWindow newManagerWindow = new AddNewManagerWindow();
            SetCenterPositionAndOpen(newManagerWindow);
        }
        private void OpenAddClientWindowMethod()
        {
            AddNewClientWindow newClientWindow = new AddNewClientWindow();
            SetCenterPositionAndOpen(newClientWindow);
        }
        private void OpenAddProductWindowMethod()
        {
            AddNewProductWindow newProductWindow = new AddNewProductWindow();
            SetCenterPositionAndOpen(newProductWindow);
        }

        // methods of editing windows
        private void OpenEditManagerWindowMethod(Manager manager)
        {
            EditManagerWindow editManagerWindow = new EditManagerWindow(manager);
            SetCenterPositionAndOpen(editManagerWindow);
        }
        private void OpenEditClientWindowMethod(Client client)
        {
            EditClientWindow editClientWindow = new EditClientWindow(client);
            SetCenterPositionAndOpen(editClientWindow);
        }
        private void OpenEditProductWindowMethod(Product product)
        {
            EditProductWindow editProductWindow = new EditProductWindow(product);
            SetCenterPositionAndOpen(editProductWindow);
        }
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #endregion

        #region EDIT COMMANDS



        private RelayCommand editManager;
        public RelayCommand EditManager
        {
            get
            {
                return editManager ?? new RelayCommand(obj => {
                    Window window = obj as Window;
                    string resultStr = "Manager is not selected";
                    if (SelectedManagerLine != null)
                    {
                        resultStr = DataManipulator.EditManager(SelectedManagerLine, ManagerName);
                        UpdateAllData();
                        SetNullValues();
                        ShowMessage(resultStr);
                        window.Close();
                    }
                    else ShowMessage(resultStr);
                
                });
            }
        }
        private RelayCommand editClient;
        public RelayCommand EditClient
        {
            get
            {
                return editClient ?? new RelayCommand(obj => {
                    Window window = obj as Window;
                    string resultStr = "Client is not selected";
                    string NoStatus = "Choose client status";
                    if (SelectedClientLine != null)
                    {
                        if (SelectedClientStatus != null)
                        {
                            resultStr = DataManipulator.EditClient(SelectedClientLine, ClientName, SelectedClientStatus, ClientManager);
                            UpdateAllData();
                            SetNullValues();
                            ShowMessage(resultStr);
                            window.Close();
                        }
                        else ShowMessage(NoStatus);
                    }
                    else ShowMessage(resultStr);

                });
            }
        }
        private RelayCommand editProduct;
        public RelayCommand EditProduct
        {
            get
            {
                return editProduct ?? new RelayCommand(obj => {
                    Window window = obj as Window;
                    string resultStr = "Product is not selected";
                   
                    if (SelectedProductLine != null)
                    {
                        
                            resultStr = DataManipulator.EditProduct(SelectedProductLine, ProductName, ProductPrice, ProductSubscriptionPeriod,
                        ProductType, ProductClient);
                            UpdateAllData();
                            SetNullValues();
                            ShowMessage(resultStr);
                            window.Close();
                        
                    }
                    else ShowMessage(resultStr);

                });
            }
        }

        #endregion
        private void ShowMessage(string message)
        {
            ShowMessageWindow messageView = new ShowMessageWindow(message);
            SetCenterPositionAndOpen(messageView);
        }

        private void SetRedLightBlock(Window window, string blockName)
        {

            Control block = window.FindName(blockName) as Control;
            block.BorderBrush = Brushes.Red;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }

        }
        

    }
}
