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

        IEnumerable<ProductDTO> GetProducts(string categoryName);
        
        IEnumerable<ProductDetailsDTO> GetDetails(string productName);
    }
}
