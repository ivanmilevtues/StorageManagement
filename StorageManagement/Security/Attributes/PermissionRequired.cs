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
        public PermissionRequired(RoleDTO requeredRole)
        {
            RequeredRole = requeredRole;
        }

        public RoleDTO RequeredRole { get; }
    }
}
