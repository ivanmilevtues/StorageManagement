using System.Collections.Generic;
using System.Linq;
using DataBaseCommunication.DTO;
using DataBaseCommunication.Managers;
using DataBaseCommunication.Models;
using DataBaseCommunication.Ninject;
using Ninject;

namespace DataBaseCommunication
{
    public class DataFacade : IDataFacade
    {
        private readonly UserDBManager userManager;
        private readonly CategoryDBManager categoryManager;
        private readonly ProductDBManager productManager;

        public DataFacade()
        {
            IKernel kernel = new StandardKernel(new DataManagerModule(), new InitializersModule());
            userManager = kernel.Get<UserDBManager>();
            categoryManager = kernel.Get<CategoryDBManager>();
            productManager = kernel.Get<ProductDBManager>();
        }

        public UserDTO GetUser(string username, string password) => userManager.GetUser(username, password);

        public UserDTO GetUser(string username) => userManager.GetUser(username);

        public UserDTO CreateUser(UserDTO user) => userManager.CreateUser(user);

        public IEnumerable<UserDTO> GetUsers() => userManager.GetAll();

        public UserDTO UpdateUser(UserDTO editedUser) => userManager.Update(editedUser);

        public IEnumerable<ProductCategoryDTO> GetCategories() => categoryManager.GetAll();

        public IEnumerable<ProductDTO> GetProducts(string categoryName) => productManager.GetProducts(categoryName);

        public IEnumerable<ProductDetailsDTO> GetDetails(string productName) => productManager.GetDetails(productName);

        public void UpdateCategoryName(string oldName, string newName) => categoryManager.UpdateCategory(oldName, newName);

        public void CreateCategory(ProductCategoryDTO productCategoryDTO) => categoryManager.Create(productCategoryDTO);

        public void UpdateProductName(string oldName, string newName) => productManager.Update(oldName, newName);

        public void CreateProduct(string categoryName, ProductDTO productDTO) => productManager.Create(categoryName, productDTO);

        public void UpdateDetails(string productName, ProductDetailsDTO productDetailsDTO, int newAmount) => productManager.UpdateDetails(productName, productDetailsDTO, newAmount);

        public void CreateDetails(string productName, ProductDetailsDTO productDetailsDTO) => productManager.CreateDetails(productName, productDetailsDTO);
  
    }
}
