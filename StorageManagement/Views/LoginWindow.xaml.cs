using System.Windows;
using Ninject;
using StorageManagement.Services;
using StorageManagement.Views;

namespace StorageManagement
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private readonly UserService userService;
        private readonly StateService state;
        private readonly IKernel kernel;

        public LoginWindow(UserService userService, StateService state, IKernel kernel)
        {
            InitializeComponent();
            this.userService = userService;
            this.state = state;
            this.kernel = kernel;
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                state.User = userService.Login(usernameTextBox.Text, passwordBox.Password);
                var window = kernel.Get<MenuWindow>();
                Close();
                window.Show();
            }
            catch (InvalidLoginException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
