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

        public DataFacade()
        {
            IKernel kernel = new StandardKernel(new DataManagerModule());
            userManager = kernel.Get<UserDBManager>();
        }

        public UserDTO GetUser(string username, string password)
        {
            return userManager.GetUser(username, password);
        }

        public UserDTO GetUser(string username)
        {
            return userManager.GetUser(username);
        }

        public UserDTO CreateUser(UserDTO user)
        {
            return userManager.CreateUser(user);
        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return userManager.GetAll();
        }

        public UserDTO UpdateUser(UserDTO editedUser)
        {
            return userManager.Update(editedUser);
        }
    }
}
