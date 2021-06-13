using System;
using System.Collections.Generic;
using DataBaseCommunication.DTO;

namespace DataBaseCommunication
{
    public interface IDataFacade
    {
        UserDTO GetUser(string username, String password);
        UserDTO GetUser(string username);
        UserDTO CreateUser(UserDTO user);
        IEnumerable<UserDTO> GetUsers();
        UserDTO UpdateUser(UserDTO editedUser);
        IEnumerable<ProductCategoryDTO> GetCategories();
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProducts(string categoryName);
        IEnumerable<ProductDetailsDTO> GetDetails(string productName);
        void UpdateCategoryName(string oldName, string newName);
        void CreateCategory(ProductCategoryDTO productCategoryDTO);
        void UpdateProductName(string oldName, string newName);
        void CreateProduct(string categoryName, ProductDTO productDTO);
        void UpdateDetails(string productName, ProductDetailsDTO productDetailsDTO, int amount);
        void CreateDetails(string productName, ProductDetailsDTO productDetailsDTO);
        ProductDTO GetProduct(string productName);
    }
}
