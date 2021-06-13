using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseCommunication.DTO;

namespace StorageManagement.Security.Attributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    class PermissionRequired : Attribute
    {
        public PermissionRequired(params RoleDTO[] requeredRoles)
        {
            RequeredRoles = requeredRoles;
        }

        public RoleDTO[] RequeredRoles { get; }
    }
}
