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
        public AdminWindow(AdminViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
