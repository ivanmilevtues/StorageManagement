using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication;
using DataBaseCommunication.DTO;

namespace StorageManagement.Services
{
    public class ProductService
    {
        private readonly IDataFacade dataFacade;

        public ProductService(IDataFacade dataFacade)
        {
            this.dataFacade = dataFacade;
        }

        public List<ProductCategoryDTO> GetCategories()
        {
            return dataFacade.GetCategories().ToList();
        }
    }
}
