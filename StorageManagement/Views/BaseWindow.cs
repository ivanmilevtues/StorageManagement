using System.ComponentModel;
using System.Windows;

namespace StorageManagement.Views
{
    public class BaseWindow : Window
    {
        protected override void OnClosing(CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
