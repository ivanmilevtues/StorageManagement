using System.Windows;
using StorageManagement.ViewModels;

namespace StorageManagement.Views
{
    /// <summary>
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private readonly MenuWindow menuWindow;

        public ProductWindow(ProductsViewModel viewModel, MenuWindow menuWindow)
        {
            InitializeComponent();
            DataContext = viewModel;
            this.menuWindow = menuWindow;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
            menuWindow.Show();
        }
    }
}
