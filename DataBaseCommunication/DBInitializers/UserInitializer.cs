using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Cryptography;
using System.Text;
using DataBaseCommunication.Models;

namespace DataBaseCommunication.DBInitializers
{
    class UserInitializer: DropCreateDatabaseAlways<StorageManagementDBContext>
    {
        private readonly HashAlgorithm hasher = new SHA1CryptoServiceProvider();

        protected override void Seed(StorageManagementDBContext context)
        {
            IList<User> users = new List<User>
            {
                new User { Username = "admin", Password = HashPassword("admin"), Role = Role.Admin }
            };

            context.Users.AddRange(users);
            
            base.Seed(context);
        }

        private string HashPassword(string password)
        {
            var data = Encoding.ASCII.GetBytes(password);

            hasher.ComputeHash(data);

            return new ASCIIEncoding().GetString(data, 0, data.Length);
        }

    }
}
