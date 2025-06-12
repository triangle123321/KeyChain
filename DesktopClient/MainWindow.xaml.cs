using System.Windows;
using System.Windows.Controls;
using GameKeyManager.Views;
using GameKeyManager.Services;
using GameKeyManager.ViewModels;

namespace GameKeyManager
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void UpdateNavigationButtons(Button activeButton)
        {
            // Reset all navigation buttons to normal style
            BtnLibrary.Style = (Style)FindResource("NavButton");
            BtnAddGame.Style = (Style)FindResource("NavButton");
            BtnSettings.Style = (Style)FindResource("NavButton");
            BtnAccount.Style = (Style)FindResource("NavButton");
            BtnLogin.Style = (Style)FindResource("NavButton");

            // Set active button style
            activeButton.Style = (Style)FindResource("ActiveNavButton");
        }

        // Action Button Methods
        private void BtnSync_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Sync functionality will be implemented later.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnBackup_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Backup functionality will be implemented later.", "Info",
                MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void BtnAddGame_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}