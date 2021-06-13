using System.Windows;
using StorageManagement.Services;
using StorageManagement.ViewModels;

namespace StorageManagement.Views
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : BaseWindow
    {
        private readonly MenuWindow menuWindow;

        public AdminWindow(AdminViewModel viewModel, MenuWindow menuWindow)
        {
            this.menuWindow = menuWindow;
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
