using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication;
using DataBaseCommunication.DTO;
using StorageManagement.Models;

namespace StorageManagement.Services
{
    public class ProductService
    {
        private readonly IDataFacade dataFacade;

        public ProductService(IDataFacade dataFacade)
        {
            this.dataFacade = dataFacade;
        }

        public List<Category> GetCategories()
        {
            return dataFacade.GetCategories().Select(c => new Category(c.Name)).ToList();
        }

        public List<Product> GetProducts(string categoryName)
        {
            return dataFacade.GetProducts(categoryName).Select(p => new Product(p.Name, p.Description, p.Amount)).ToList();
        }

        public List<Details> GetDetails(string productName)
        {
            return dataFacade.GetDetails(productName)
                .Select(pd => new Details(pd.DeliveryDate, pd.ProductionDate, pd.ExpirationDate, pd.Amount)).ToList();

        }
    }
}
