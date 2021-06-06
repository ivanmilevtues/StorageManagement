using System.Linq;
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

        public User GetUser(string username, string password)
        {
            return userManager.GetUser(username, password);
        }

        public User CreateUser(string username, string password, Role userRole)
        {
            return userManager.CreateUser(username, password, userRole);
        }

        public IQueryable<User> GetUsers()
        {
            return userManager.GetAll();
        }
    }
}
