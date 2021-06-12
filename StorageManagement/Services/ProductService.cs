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
            return dataFacade.GetCategories().Select(c => new Category() { Name = c.Name }).ToList();
        }

        public List<Product> GetProducts(string categoryName)
        {
            return dataFacade.GetProducts(categoryName).Select(p => new Product() { Name = p.Name, Description = p.Description, Amount = p.Amount }).ToList();
        }

        public List<Details> GetDetails(string productName)
        {
            return dataFacade.GetDetails(productName)
                .Select(pd => new Details() { DeliveryDate = pd.DeliveryDate, ProductionDate = pd.ProductionDate, ExpirationDate = pd.ExpirationDate, Amount = pd.Amount }).ToList();

        }

        public void UpdateCategory(Category selectedCategory, Category category)
        {

            dataFacade.UpdateCategoryName(selectedCategory.Name, category.Name);
        }

        public void CreateCategory(Category category)
        {
            dataFacade.CreateCategory(new ProductCategoryDTO { Name = category.Name, Products = new List<ProductDTO>() });
        }

        public void UpdateProduct(Product selectedProduct, Product product)
        {
            dataFacade.UpdateProductName(selectedProduct.Name, product.Name);
        }

        public void CreateProduct(Category category, Product product)
        {
            dataFacade.CreateProduct(category.Name, new ProductDTO { Name = product.Name, Description = product.Description, Amount = 0, ProductCategories = new List<ProductCategoryDTO>(), ProductDetails = new List<ProductDetailsDTO>() });
        }

        public void UpdateDetails(Product selectedProduct, Details selectedDetails, Details details)
        {
            int newAmount = selectedDetails.Amount - details.Amount;
            dataFacade.UpdateDetails(selectedProduct.Name,
                new ProductDetailsDTO 
                { 
                    Amount = selectedDetails.Amount, 
                    DeliveryDate = selectedDetails.DeliveryDate, 
                    ExpirationDate = selectedDetails.ExpirationDate, 
                    ProductionDate = selectedDetails.ProductionDate 
                },
                newAmount);
        }

        public void CreateDetails(Product selectedProduct, Details details)
        {
            dataFacade.CreateDetails(selectedProduct.Name, new ProductDetailsDTO
            {
                Amount = details.Amount,
                DeliveryDate = details.DeliveryDate,
                ExpirationDate = details.ExpirationDate,
                ProductionDate = details.ProductionDate
            });
        }
    }
}
