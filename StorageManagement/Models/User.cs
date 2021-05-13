using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageManagement
{
    public class User
    {
        public String Username { get; private set; }

        public String Password { get; private set; }

        public User(string username, string password)
        {
            this.Username = username;
            this.Password = password;
        }
    }
}
