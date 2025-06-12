using GameKeyManager.Services;
using GameKeyManager.ViewModels;
using System.Configuration;
using System.Data;
using System.Windows;

namespace GameKeyManager
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            // Initialize the main window with the MainWindowViewModel
            IAuthService authService = new AuthService();

            var mainWindowViewModel = new MainWindowViewModel(authService);
            var mainWindow = new MainWindow
            {
                DataContext = mainWindowViewModel
            };
            mainWindow.Show();
        }
    }

}
