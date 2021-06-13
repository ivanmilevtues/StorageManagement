using System.Windows;
using DataBaseCommunication.DTO;
using Ninject;
using StorageManagement.Services;

namespace StorageManagement.Views
{
    /// <summary>
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        private readonly IKernel kernel;

        public MenuWindow(IKernel kernel)
        {
            this.kernel = kernel;
            InitializeComponent();
            var loggedUser = kernel.Get<StateService>().User;
            UsernameLabel.Content = loggedUser.Username;
            RoleLabel.Content = loggedUser.Role;
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(kernel.Get<ProductWindow>());
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(kernel.Get<AdminWindow>());
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(kernel.Get<LoginWindow>());
        }

        private void Report_Click(object sender, RoutedEventArgs e)
        {
            ShowWindow(kernel.Get<ReportsWindow>());
        }

        private void ShowWindow(Window window)
        {
            Hide();
            window.Show();
        }
    }
}
