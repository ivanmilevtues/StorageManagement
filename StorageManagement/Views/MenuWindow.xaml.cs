using System.Windows;
using Ninject;

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
        }

        private void Storage_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            var window = kernel.Get<AdminWindow>();
            Close();
            window.Show();
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            var window = kernel.Get<LoginWindow>();
            Close();
            window.Show();
        }
    }
}
