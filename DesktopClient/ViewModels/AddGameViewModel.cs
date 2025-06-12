using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using GameKeyManager.Helpers;

namespace GameKeyManager.ViewModels
{
    public class AddGameViewModel : INotifyPropertyChanged
    {
        private string _gameTitle = string.Empty; // Initialize to avoid nullability warnings
        private string _platform = string.Empty; // Initialize to avoid nullability warnings
        private string _productKey = string.Empty; // Initialize to avoid nullability warnings
        // private string _price = string.Empty; // Initialize to avoid nullability warnings, for future implementation
        private string _notes = string.Empty; // Initialize to avoid nullability warnings

        public List<string> Platforms { get; } =
        [
        "Steam", "Epic Games", "Origin", "Ubisoft Connect", "GOG",
        "Battle.net", "Xbox Game Pass", "PlayStation", "Nintendo", "Other"
        ];

        public string GameTitle
        {
            get => _gameTitle;
            set { _gameTitle = value; OnPropertyChanged(nameof(GameTitle)); }
        }
        public string Platform
        {
            get => _platform;
            set { _platform = value; OnPropertyChanged(nameof(Platform)); }
        }
        public string ProductKey
        {
            get => _productKey;
            set { _productKey = value; OnPropertyChanged(nameof(ProductKey)); }
        }
        public string Notes
        {
            get => _notes;
            set { _notes = value; OnPropertyChanged(nameof(Notes)); }
        }
        public ICommand SaveGameCommand { get; }
        public ICommand ClearFormCommand { get; }
        public ICommand CancelCommand { get; }
        public AddGameViewModel()
        {
            SaveGameCommand = new RelayCommand(SaveGame);
            ClearFormCommand = new RelayCommand(ClearForm);
            CancelCommand = new RelayCommand(Cancel);
        }

        private async void SaveGame(object parameter)
        {
            if(!ValidateForm())
            {
                return;
            }
            // Logic to save the game to the database or backend service


        }

        private void ClearForm(object? parameter = null)
        {
            GameTitle = string.Empty;
            Platform = string.Empty;
            ProductKey = string.Empty;
            Notes = string.Empty;
            // Reset other fields if needed
        }

        // Keep Cancel method for now, remove on refactor with button
        private void Cancel(object parameter)
        {
            // Logic to handle cancellation, e.g., closing the form or navigating back
            ClearForm();
            // Raise an event or call a method to notify the view
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(GameTitle))
            {
                // Show validation error for GameTitle
                MessageBox.Show("Game Title is required.", "Validation Error");
                return false;
            }
            if (string.IsNullOrWhiteSpace(Platform))
            {
                // Show validation error for Platform
                MessageBox.Show("Platform is required.", "Validation Error");
                return false;
            }
            if (string.IsNullOrWhiteSpace(ProductKey))
            {
                // Show validation error for ProductKey
                MessageBox.Show("Product Key is required.", "Validation Error");
                return false;
            }
            // Additional validations can be added here
            return true;
        }
        public event PropertyChangedEventHandler? PropertyChanged; // Fix CS8612/CS8618: Nullable event
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
