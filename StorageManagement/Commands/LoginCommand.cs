using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StorageManagement.Commands
{
    class LoginCommand : ICommand
    {
        private LoginViewModel loginViewModel;

        public event EventHandler CanExecuteChanged;

        public LoginCommand(LoginViewModel viewModel)
        {
            this.loginViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return this.loginViewModel.CanLogin;
        }

        public void Execute(object parameter)
        {
            loginViewModel.Login();
        }
    }
}
