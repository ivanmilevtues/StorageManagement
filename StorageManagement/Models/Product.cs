using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement.Models
{
    public class Product
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public Product(string name, string description, int amount)
        {
            Name = name;
            Amount = amount;
            Description = description;
        }
    }
}
