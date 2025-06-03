using System.Windows;
using System.Windows.Controls;
using GameKeyManager.Views;

namespace GameKeyManager
{
    public partial class MainWindow : Window
    {
        private readonly AddGameView _addGameView;
        private readonly LibraryView _libraryView;
        private readonly SettingsView _settingsView;
        private readonly AccountView _accountView;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize views
            _addGameView = new AddGameView();
            _libraryView = new LibraryView();
            _settingsView = new SettingsView();
            _accountView = new AccountView();

            // Wire up view events
            _addGameView.GameSaved += (s, e) => NavigateToLibrary();
            _addGameView.CancelRequested += (s, e) => NavigateToLibrary();

            // Set initial view
            NavigateToLibrary();
        }

        // Navigation Methods
        private void BtnLibrary_Click(object sender, RoutedEventArgs e) => NavigateToLibrary();
        private void BtnAddGame_Click(object sender, RoutedEventArgs e) => NavigateToAddGame();
        private void BtnSettings_Click(object sender, RoutedEventArgs e) => NavigateToSettings();
        private void BtnAccount_Click(object sender, RoutedEventArgs e) => NavigateToAccount();
        private void BtnLogin_Click(object sender, RoutedEventArgs e) => NavigateToLogin();

        private void NavigateToLibrary()
        {
            _libraryView.RefreshData(); // Ensure the view is refreshed before displaying  
            ContentContainer.Children.Clear(); // Clear existing children in the Grid  
            ContentContainer.Children.Add(_libraryView); // Add the LibraryView to the Grid  
            UpdateNavigationButtons(BtnLibrary);
            TxtPageTitle.Text = "My Game Library";
        }

        private void NavigateToAddGame()
        {
            ContentContainer.Children.Clear(); // Clear existing children in the Grid  
            ContentContainer.Children.Add(_addGameView); // Add the AddGameView to the Grid  
            UpdateNavigationButtons(BtnAddGame);
            TxtPageTitle.Text = "Add New Game";
        }

        private void NavigateToSettings()
        {
            ContentContainer.Children.Clear(); // Clear existing children in the Grid  
            ContentContainer.Children.Add(_settingsView); // Add the SettingsView to the Grid  
            UpdateNavigationButtons(BtnSettings);
            TxtPageTitle.Text = "Settings";
        }

        private void NavigateToAccount()
        {
            ContentContainer.Children.Clear(); // Clear existing children in the Grid  
            ContentContainer.Children.Add(_accountView); // Add the AccountView to the Grid  
            UpdateNavigationButtons(BtnAccount);
            TxtPageTitle.Text = "Account";
        }

        private void NavigateToLogin()
        {
            ContentContainer.Children.Clear(); // Clear existing children in the Grid  
            ContentContainer.Children.Add(new LoginView()); // Add the LoginView to the Grid  
            UpdateNavigationButtons(BtnLogin);
            TxtPageTitle.Text = "Login";
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
    }
}