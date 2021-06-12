using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.DTO
{

    public class ProductCategoryDTO
    {
        public string Name { get; set; }

        public ICollection<ProductDTO> Products { get; set; }
    }

    public class ProductDTO
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int Amount { get; set; }

        public ICollection<ProductDetailsDTO> ProductDetails { get; set; }
    }

    public class ProductDetailsDTO
    {
        public DateTime DeliveryDate { get; set; }

        public DateTime ProductionDate { get; set; }

        public DateTime? ExpirationDate { get; set; }

        public ProductDTO Product { get; set; }

        public int Amount { get; set; }
    }
}
