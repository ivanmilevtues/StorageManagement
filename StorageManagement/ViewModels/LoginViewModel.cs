using System;
using System.Windows;
using System.Windows.Input;
using StorageManagement.Commands;

namespace StorageManagement
{
    public class LoginViewModel
    {
        public User User { get; }

        public LoginViewModel()
        {
            User = new User("", "");
            LoginCommand = new LoginCommand(this);
        }

        public ICommand LoginCommand
        {
            get;
            private set;
        }
        public bool CanLogin {
            get
            {
                return String.IsNullOrEmpty(User.Username) && String.IsNullOrEmpty(User.Password);
            }
        }

        internal void Login()
        {
            // TODO: This should be done via service...
            if (User.Username == "admin" && User.Password == "admin")
            {
                MessageBox.Show("You've logged in successfully!");
            }
        }
    }
}
