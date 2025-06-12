using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GameKeyManager.Helpers;
using GameKeyManager.Services;
using System.Diagnostics; // For debugging purposes, if needed
using System.Windows; 

namespace GameKeyManager.ViewModels
{
    public class LoginViewModel : INotifyPropertyChanged
    {
        private string _username = string.Empty; // Initialize to avoid nullability warnings
        private string _password = string.Empty; // Initialize to avoid nullability warnings
        private string _error = string.Empty;    // Initialize to avoid nullability warnings
        private readonly AuthService _authService = new();
        private bool _isBusy; // Used for throbber(busy indicator)

        private readonly INavigationService _navigationService;
        private readonly MainWindowViewModel _mainWindowViewModel;

        public string Username
        {
            get => _username;
            set { _username = value; OnPropertyChanged(); }
        }

        public string Password
        {
            get => _password;
            set { _password = value; OnPropertyChanged(); }
        }

        public string Error
        {
            get => _error;
            set { _error = value; OnPropertyChanged(); }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public LoginViewModel(INavigationService navigationService, MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(_ => _navigationService.NavigateTo<RegistrationViewModel>());
        }

        private async void Login(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Username and password are required.", "Validation Error");
                return;
            }

            IsBusy = true;

            try
            {
                Debug.WriteLine($"Attempting to log in with Username: {Username}");

                var result = await _authService.AuthenticateAsync(Username, Password);
                if (result.IsSuccess)
                {
                    SessionManager.CurrentUser = result.User;
                }
                else
                {
                    MessageBox.Show($"Error: {result.ErrorMessage}");
                }
            }
            finally
            {
                IsBusy = false;
                _mainWindowViewModel.RefreshAuthState();
            }

        }

        public event PropertyChangedEventHandler? PropertyChanged; // Mark as nullable to avoid warning
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
