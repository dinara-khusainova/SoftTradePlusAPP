using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradePlusAPP.Model
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ClientStatus Status { get; set; }
        public int ManagerId { get; set; }
        public Manager Manager { get; set; }
        public List<Product> PurchasedProducts { get; set; }
        [NotMapped]
        public Manager ClientManager {
            get
            {
                return DataManipulator.GetManagerById(ManagerId);
            }
        }
        [NotMapped]

        public List<Product> ClientProducts { 
            get
            {
                return DataManipulator.GetAllProductsByClientId(Id);
            } 
        }
    }

}
