using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using DataBaseCommunication.Models;

namespace DataBaseCommunication.DBInitializers
{
    class UserInitializer: ISeed
    {
        private readonly HashAlgorithm hasher = new SHA1CryptoServiceProvider();

        public void AddToSeed(ref StorageManagementDBContext context)
        {
            IList<User> users = new List<User>
            {
                new User { Username = "admin", Password = HashPassword("admin"), Role = Role.Admin },
                new User { Username = "cashier", Password = HashPassword("cashier"), Role = Role.Cashier },
                new User { Username = "supplier", Password = HashPassword("supplier"), Role = Role.Supplier }
            };

            context.Users.AddRange(users);
        }

        private string HashPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            data = hasher.ComputeHash(data);

            return new ASCIIEncoding().GetString(data, 0, data.Length);
        }

    }
}
