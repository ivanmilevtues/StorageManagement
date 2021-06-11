using System.Collections.Generic;
using DataBaseCommunication.DTO;
using StorageManagement.Services;

namespace StorageManagement.ViewModels
{
    public class ProductCategoryViewModel
    {
        public List<ProductCategoryDTO> Categories { get; set; }

        private readonly ProductService productService;

        public ProductCategoryViewModel(ProductService productService)
        {
            this.productService = productService;
            Categories = productService.GetCategories();
        }
    }
}
