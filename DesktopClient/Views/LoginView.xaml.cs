using System.Windows;
using System.Windows.Controls;

namespace GameKeyManager.Views
{
    public partial class LoginView : UserControl
    {
        public LoginView()
        {
            InitializeComponent();
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sync functionality will be implemented later.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnRegister_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sync functionality will be implemented later.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
