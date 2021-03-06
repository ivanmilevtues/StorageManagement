using AutoMapper;
using DataBaseCommunication.Models;
using DataBaseCommunication.DTO;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using System;

namespace DataBaseCommunication.Managers
{
    internal class CategoryDBManager: AbstractDbManager<ProductCategory, ProductCategoryDTO>
    {
        public CategoryDBManager(StorageManagementDBContext dBContext, IMapper dtoMapper) : base(dBContext, dtoMapper)
        { }

        public IEnumerable<ProductCategoryDTO> GetAll() => dbContext.ProductCategories.AsEnumerable().Select(p => MapToDTO(p));

        public ProductCategoryDTO AddCategory(ProductCategoryDTO category)
        {
            var categoryEntity = dbContext.ProductCategories.Add(MapToModel(category));
            return MapToDTO(categoryEntity);
        }

        public void RemoveCategory(ProductCategoryDTO category)
        {
            var categoryEntity = dbContext.ProductCategories.Where(x => category.Name == x.Name).First();
            dbContext.Entry(categoryEntity).State = EntityState.Deleted;
            dbContext.SaveChanges();
        }

        public ProductCategoryDTO UpdateCategory(string categoryName, string newName)
        {
            var categoryEntity = dbContext.ProductCategories.Where(x => categoryName == x.Name).First();
            categoryEntity.Name = newName;
            dbContext.SaveChanges();

            return MapToDTO(categoryEntity);
        }

        public void Create(ProductCategoryDTO productCategoryDTO)
        {
            var categoryEntity = MapToModel(productCategoryDTO);
            dbContext.ProductCategories.Add(categoryEntity);
            dbContext.SaveChanges();
        }
    }
}
