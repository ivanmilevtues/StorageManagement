using System.Linq;
using DataBaseCommunication.Models;

namespace DataBaseCommunication.Managers
{
    internal class UserDBManager : AbstractDbManager
    {

        public UserDBManager(StorageManagementDBContext dBContext) : base(dBContext) { }

        public User GetUser(string username, string password) => dbContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

        public IQueryable<User> GetAll() => dbContext.Users;

        public User CreateUser(string username, string password, Role role)
        {
            var newUser = new User()
            {
                Username = username,
                Password = password,
                Role = role
            };
            dbContext.Users.Add(newUser);
            dbContext.SaveChanges();

            return newUser;
        }
    }
}
