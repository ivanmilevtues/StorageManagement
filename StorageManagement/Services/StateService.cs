using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.DTO;

namespace StorageManagement.Services
{
    public class StateService
    {

        private UserDTO _user;

        public UserDTO User {
            get
            {
                if(_user == null)
                {
                    return new UserDTO()
                    {
                        Username = "basicUser",
                        Role = RoleDTO.Supplier
                    };
                }
                return _user;
            } 
            set
            {
                _user = value;
            }
        }
    }
}
