using System;
using System.Windows;
using System.Windows.Controls;

namespace StorageManagement.Views
{
    /// <summary>
    /// Interaction logic for LoggedUserControl.xaml
    /// </summary>
    public partial class LoggedUserControl : UserControl
    {

        public static readonly DependencyProperty UsernameProperty = 
            DependencyProperty.Register("Username", typeof(string), typeof(UserControl), new FrameworkPropertyMetadata(null));

        public string Username {
            get { return (string)GetValue(UsernameProperty); }
            set { SetValue(UsernameProperty, value); }
        }

        public LoggedUserControl()
        {
            InitializeComponent();
            Loaded += LateInit;
        }

        private void LateInit(object sender, RoutedEventArgs e)
        {
            UsernameLabel.Content = Username;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach(Window window in Application.Current.Windows)
            {
                if(window is MenuWindow)
                {
                    window.Show();
                    break;
                }
            }
            Window.GetWindow(this).Close();
        }
    }
}
