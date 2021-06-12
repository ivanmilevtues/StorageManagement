using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataBaseCommunication.DTO;
using DataBaseCommunication.Models;

namespace DataBaseCommunication.Managers
{
    internal class ProductDBManager : AbstractDbManager<Product, ProductDTO>
    {
        public ProductDBManager(StorageManagementDBContext dbContext, IMapper dtoMapper) : base(dbContext, dtoMapper)
        { }

        public ProductDTO AddProduct(ProductDTO newProduct)
        {
            var product = dbContext.Products.Add(MapToModel(newProduct));
            return MapToDTO(product);
        }

        public ProductDTO RemoveProductAmount()
        {
            return null;
        }

        public IEnumerable<ProductDTO> GetAll() => dbContext.Products.AsEnumerable().Select(p => MapToDTO(p));

        public IEnumerable<ProductDTO> GetProducts(string categoryName) => dbContext.Products
                                                                                    .Where(p => p.ProductCategories.Where(c => c.Name == categoryName).Any())
                                                                                    .AsEnumerable()
                                                                                    .Select(p => MapToDTO(p));

        public IEnumerable<ProductDetailsDTO> GetDetails(string productName) => dbContext.ProductDetails
                                                                                    .Where(pd => pd.Product.Name == productName)
                                                                                    .AsEnumerable()
                                                                                    .Select(pd => dtoMapper.Map<ProductDetails, ProductDetailsDTO>(pd));
    }
}
