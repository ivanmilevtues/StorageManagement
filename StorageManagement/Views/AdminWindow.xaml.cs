using System.Windows;
using StorageManagement.Services;
using StorageManagement.ViewModels;

namespace StorageManagement.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private MenuWindow menuWindow;

        public AdminWindow(AdminViewModel viewModel, MenuWindow menuWindow)
        {
            this.menuWindow = menuWindow;
            InitializeComponent();
            DataContext = viewModel;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            menuWindow.Show();
        }
    }
}
