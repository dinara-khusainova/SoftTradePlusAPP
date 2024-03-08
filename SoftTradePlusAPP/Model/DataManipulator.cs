using Microsoft.EntityFrameworkCore;
using SoftTradePlusAPP.Model.Data;
using SoftTradePlusAPP.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradePlusAPP.Model
{
    public static class DataManipulator
    {
        // Get list of Managers
        public static List<Manager> ListOfManagers()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Managers.Include(m => m.Clients).ToList();
                return result;
            }
        }
        // Get list of Clients
        public static List<Client> ListOfClients()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Clients.ToList();
                return result;
            }
        }
        // Get list of Products
        public static List<Product> ListOfProducts()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Products.ToList();
                return result;
            }
        }
        //Create new manager
        public static string CreateManager(string name)
        {
            string result = "Already exists";
            using (ApplicationContext db = new ApplicationContext())
            {
                
                bool IsExist = db.Managers.Any(m => m.Name == name);
                if (!IsExist)
                {
                    Manager newManager = new Manager { Name = name };
                    db.Managers.Add(newManager);
                    db.SaveChanges();
                    result = "A new manager has been added.";
                }
                return result;
            }
        }
        //Create new client
        public static string CreateClient(string name, ClientStatus status, Manager manager)
        {
            string result = "Already exists";
            using (ApplicationContext db = new ApplicationContext())
            {
                
                bool IsExist = db.Clients.Any(m => m.Name == name && m.Status == status);
                if (!IsExist)
                {
                    Client newClient = new Client
                    {
                        Name = name,
                        Status = status,
                        ManagerId = manager.Id,
                        
                    };
                    db.Clients.Add(newClient);
                    db.SaveChanges();
                    result = "A new client has been added.";
                    
                }
                return result;
            }
        }
        //Create new product
        public static string CreateProduct(string name, decimal price, SubscriptionPeriod subscriptionPeriod,
            SubscriptionType type, Client Client)
        {
            string result = "Already exists";
            using (ApplicationContext db = new ApplicationContext())
            {
               
                bool IsExist = db.Products.Any(m => m.Name == name && m.Price == price && m.Type == type);
                if (!IsExist)
                {
                    Product newProduct = new Product
                    {
                        Name = name,
                        Price = price,
                        SubscriptionPeriod = subscriptionPeriod,
                        Type = type,
                        ClientId = Client.Id

                    };
                    db.Products.Add(newProduct);
                    db.SaveChanges();
                    result = "A new product has been added.";
                }
                return result;
            }
        }
        // Delete manager
        public static string DeleteManager(Manager manager)
        {
            string result = "There is no such manager.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Managers.Remove(manager);
                db.SaveChanges();
                result = "Manager " + manager.Name + " has been removed.";
            }
            return result;
        }
        // Delete client
        public static string DeleteClient(Client client)
        {
            string result = "There is no such client.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Clients.Remove(client);
                db.SaveChanges();
                result = "Client " + client.Name + " has been removed.";
            }
            return result;
        }
        // Delete product
        public static string DeleteProduct(Product product)
        {
            string result = "There is no such manager.";
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Products.Remove(product);
                db.SaveChanges();
                result = "Product " + product.Name + " has been removed.";
            }
            return result;
        }

        //Edit manager
        public static string EditManager(Manager currentManager, string newName)
        {
            string result = "There is no such manager.";
            using (ApplicationContext db = new ApplicationContext())
            {
                Manager manager = db.Managers.FirstOrDefault(m => m.Id == currentManager.Id);
                if (manager != null)
                {
                    manager.Name = newName;
                    db.SaveChanges();
                    result = "Manager " + manager.Name + " has been edited.";
                }

            }
            return result;
        }


        //Edit client
        public static string EditClient(Client currentClient, string newName, ClientStatus newStatus, Manager newManager)
        {
            string result = "There is no such client.";
            using (ApplicationContext db = new ApplicationContext())
            {
                Client client = db.Clients.FirstOrDefault(m => m.Id == currentClient.Id);
                if (client != null)
                {
                    client.Name = newName;
                    client.Status = newStatus;
                    client.ManagerId = newManager.Id;
                    db.SaveChanges();
                    result = "Client " + client.Name + " has been edited.";
                }

            }
            return result;
        }


        //Edit product
        public static string EditProduct(Product currentProduct, string newName, decimal newPrice, SubscriptionPeriod newSubscriptionPeriod,
            SubscriptionType newType, Client newClient)
        {
            string result = "There is no such product.";
            using (ApplicationContext db = new ApplicationContext())
            {
                Product product = db.Products.FirstOrDefault(m => m.Id == currentProduct.Id);
                if (product != null)
                {
                    product.Name = newName;
                    product.Price = newPrice;
                    product.Type = newType;
                    product.ClientId = newClient.Id;
                    db.SaveChanges();
                    result = "Product " + product.Name + " has been edited.";

                }

            }
            return result;
        }
       
        public static Manager GetManagerById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Manager position = db.Managers.FirstOrDefault(pos => pos.Id == id);
                return position;
            }
        }
        public static Client GetClientById(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Client client = db.Clients.FirstOrDefault(c => c.Id == id);
                return client;
            }
        }

        public static List<Product> GetAllProductsByClientId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
               List<Product> products = (from product in ListOfProducts() where product.ClientId == id select product).ToList();
                return products;
            }
        }


    }
}
