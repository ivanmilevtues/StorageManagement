using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Details
    {
        public DateTime DeliveryDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public int Amount { get; set; }

        public Details(DateTime deliverDate, DateTime productionDate, DateTime? expirationDate, int amount)
        {
            DeliveryDate = deliverDate;
            ProductionDate = productionDate;
            ExpirationDate = expirationDate;
            Amount = amount;
        }
    }
}
