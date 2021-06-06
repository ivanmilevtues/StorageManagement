using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Ninject;
using StorageManagement.Ninject;
using StorageManagement.Views;

namespace StorageManagement
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IKernel kernel;

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            kernel = new StandardKernel(new SecondPartyModule(), new ServicesModule());
            Current.MainWindow = kernel.Get<LoginWindow>();
            Current.MainWindow.Show();
        }
    }
}
