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
    }
}
