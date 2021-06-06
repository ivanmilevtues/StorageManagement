using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseCommunication.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public RoleDTO Role { get; set; }
    }

    public enum RoleDTO
    {
        Admin,
        Cashier,
        Supplier
    }
}
