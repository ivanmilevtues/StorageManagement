using System;
using System.Linq;
using System.Windows.Input;
using DataBaseCommunication.DTO;
using StorageManagement.Security.Attributes;

namespace StorageManagement.Commands
{
    class PermissionRequiredCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private readonly Action action;
        private readonly RoleDTO userRole;

        public PermissionRequiredCommand(Action action, RoleDTO userRole)
        {
            this.action = action;
            this.userRole = userRole;
        }

        public bool CanExecute(object parameter)
        {
            return HasPermission();
        }

        public void Execute(object parameter)
        {
            action();
        }

        private bool HasPermission()
        {
            var methodAttributes = action.Method.GetCustomAttributes(true);
            if (methodAttributes.Length == 0)
            {
                return true;
            }

            return methodAttributes.Any(attr => (attr is PermissionRequired) && (attr as PermissionRequired).RequeredRole <= userRole);
        }
    }
}
