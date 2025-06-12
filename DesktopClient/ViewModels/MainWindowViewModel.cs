using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using GameKeyManager.Helpers;
using GameKeyManager.Services;

namespace GameKeyManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly IAuthService _authService;
        private object _currentViewModel = null!;
        public object CurrentViewModel
        {
            get => _currentViewModel;
            set { _currentViewModel = value; OnPropertyChanged(); }
        }

        public INavigationService NavigationService { get; }

        // Example navigation commands
        public ICommand ShowAccountCommand { get; }
        public ICommand ShowAddGameCommand { get; }
        
        public ICommand ShowLibraryCommand { get; }
        public ICommand ShowLoginCommand { get; }
        public ICommand ShowSettingsCommand { get; }
        public ICommand ShowRegisterCommand { get; }
        // Add more commands as needed

        public MainWindowViewModel(IAuthService authService)
        {

            _authService = authService;
            NavigationService = new NavigationService(this);

            // Register factory for Login-/RegistrationViewModel (requires INavigationService)
            NavigationService.Register(() => new LoginViewModel(NavigationService, this));
            NavigationService.Register(() => new RegistrationViewModel(NavigationService, this));

            // Set initial view
            CurrentViewModel = new LibraryViewModel();

            // Set up navigation commands
            ShowAccountCommand = new RelayCommand(_ => NavigationService.NavigateTo<AccountViewModel>());
            ShowAddGameCommand = new RelayCommand(_ => NavigationService.NavigateTo<AddGameViewModel>());
            ShowLibraryCommand = new RelayCommand(_ => NavigationService.NavigateTo<LibraryViewModel>());
            ShowLoginCommand = new RelayCommand(_ => NavigationService.NavigateTo<LoginViewModel>());
            ShowSettingsCommand = new RelayCommand(_ => NavigationService.NavigateTo<SettingsViewModel>());
            ShowRegisterCommand = new RelayCommand(_ => NavigationService.NavigateTo<RegistrationViewModel>());
        }
        
        public bool IsAuthenticated => _authService.IsAuthenticated;

        public void RefreshAuthState()
        {
            OnPropertyChanged(nameof(IsAuthenticated));
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}