using System.ComponentModel;
using System.Runtime.CompilerServices;
using GameKeyManager.Services;
using GameKeyManager.Helpers;
using System.Diagnostics; // For debugging purposes, if needed
using System.Windows;
using System.Windows.Input;

namespace GameKeyManager.ViewModels
{
    public class RegistrationViewModel : INotifyPropertyChanged
    {
        private string _username = string.Empty; // Initialize to avoid nullability warnings
        private string _password = string.Empty; // Initialize to avoid nullability warnings
        private string _confirmPassword = string.Empty; // Initialize to avoid nullability warnings
        private string _email = string.Empty; // Initialize to avoid nullability warnings
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

        public string ConfirmPassword
        {
            get => _confirmPassword;
            set { _confirmPassword = value; OnPropertyChanged(); }
        }

        public string Email
        {
            get => _email;
            set { _email = value; OnPropertyChanged(); }
        }

        public bool IsBusy
        {
            get => _isBusy;
            set { _isBusy = value; OnPropertyChanged(); }
        }

        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }

        public RegistrationViewModel(INavigationService navigationService, MainWindowViewModel mainWindowViewModel)
        {
            _navigationService = navigationService;
            LoginCommand = new RelayCommand(_ => _navigationService.NavigateTo<LoginViewModel>());
            RegisterCommand = new RelayCommand(Register);
            _mainWindowViewModel = mainWindowViewModel;
        }

        private async void Register(object parameter)
        {
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("Username and password are required.", "Validation Error");
                return;
            }
            if (Password != ConfirmPassword)
            {
                MessageBox.Show("Passwords do not match.", "Validation Error");
                return;
            }
            IsBusy = true;

            try
            {
                Debug.WriteLine($"Attempting to register with Username: {Username}");
                var response = await RegistrationService.RegisterAsync(Username, Password, Email); // Fixed by qualifying with the type name
                
                if (response.User != null)
                {
                    MessageBox.Show("Registration successful!", "Success");
                    // Navigate to login or main view
                }
                else
                {
                    MessageBox.Show(response.ErrorMessage ?? "Registration failed. Please try again.", "Error");
                    Debug.WriteLine($"Registration failed: {response.ErrorMessage}"); // Log the error for debugging
                }

            }
            finally
            {
                IsBusy = false;
                _mainWindowViewModel.RefreshAuthState(); // Refresh authentication state in the main view model
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Mark as nullable to avoid warning
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
