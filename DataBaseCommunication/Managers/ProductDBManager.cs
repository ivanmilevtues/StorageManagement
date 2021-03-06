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

        public IEnumerable<ProductDTO> GetAll() => dbContext.Products.Include("ProductCategories").Include("ProductDetails").AsEnumerable().Select(p => MapToDTO(p));

        public IEnumerable<ProductDTO> GetProducts(string categoryName) => dbContext.Products
                                                                                    .Include("ProductDetails")
                                                                                    .Where(p => p.ProductCategories.Where(c => c.Name == categoryName).Any())
                                                                                    .AsEnumerable()
                                                                                    .Select(p => MapToDTO(p));

        public IEnumerable<ProductDetailsDTO> GetDetails(string productName) => dbContext.ProductDetails
                                                                                    .Where(pd => pd.Product.Name == productName)
                                                                                    .AsEnumerable()
                                                                                    .Select(pd => dtoMapper.Map<ProductDetails, ProductDetailsDTO>(pd));

        public void Update(string oldName, string newName)
        {
            var productEntity = GetProduct(oldName);
            productEntity.Name = newName;
            dbContext.SaveChanges();
        }

        public void Create(string categoryName, ProductDTO productDTO)
        {
            var categoryEntity = dbContext.ProductCategories.Where(c => c.Name == categoryName).First();
            var productEntity = MapToModel(productDTO);
            productEntity.ProductCategories.Add(categoryEntity);
            dbContext.Products.Add(productEntity);
            dbContext.SaveChanges();
        }

        public void CreateDetails(string productName, ProductDetailsDTO productDetailsDTO)
        {
            var productEntity = GetProduct(productName);
            var detailsEntity = dtoMapper.Map<ProductDetailsDTO, ProductDetails>(productDetailsDTO);

            if(detailsEntity.IsInDelivery)
            {
                productEntity.Amount += detailsEntity.Amount;
            } else
            {
                productEntity.Amount -= detailsEntity.Amount;
            }
            detailsEntity.Product = productEntity;

            dbContext.ProductDetails.Add(detailsEntity);
            dbContext.SaveChanges();
        }

        public ProductDTO GetProductWithDetails(string productName)
        {
            var productEntity = dbContext.Products.Include("ProductDetails").Where(p => p.Name == productName).FirstOrDefault();
            return MapToDTO(productEntity);
        }

        public void UpdateDetails(string productName, ProductDetailsDTO productDetailsDTO, int newAmount)
        {
            var productEntity = GetProduct(productName);
            var detailsEntity  = dbContext.ProductDetails.Where(pd => pd.Product.Name == productName).Where(pd =>
                pd.ProductionDate == productDetailsDTO.ProductionDate && pd.DeliveryDate == productDetailsDTO.DeliveryDate).FirstOrDefault();

            productEntity.Amount -= detailsEntity.Amount - newAmount;
            detailsEntity.Amount = newAmount;            

            dbContext.SaveChanges();
        }

        private Product GetProduct(string name)
        {
            return dbContext.Products.Where(p => p.Name == name).FirstOrDefault();
        }
    }
}
