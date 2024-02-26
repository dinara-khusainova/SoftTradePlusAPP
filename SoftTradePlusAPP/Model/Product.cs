using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftTradePlusAPP.Model
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public SubscriptionPeriod SubscriptionPeriod { get; set; }
        public SubscriptionType Type { get; set; }
        public virtual Client Client { get; set; }
        public int ClientId { get; set; }
        [NotMapped]
        public Client ProductClient
        {
            get
            {
                return DataManipulator.GetClientById(ClientId);
            }
        }

        
    }
}
