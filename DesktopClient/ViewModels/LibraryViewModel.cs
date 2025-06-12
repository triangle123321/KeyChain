using GameKeyManager.Helpers;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Input;
using GameKeyManager.Models;

namespace GameKeyManager.ViewModels
{
    public class LibraryViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Game> Games { get; set; }
        public string GameCount => $"{Games.Count} Games";
        public string TotalValue => $"Total Value: ${Games.Sum(g => decimal.Parse(g.Price.Replace("$", ""))):F2}";

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText));
                    FilterGames();
                }
            }
        }
        private List<Game> _allGames;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public LibraryViewModel()
        {
            _allGames = LoadMockGames().ToList();
            Games = new ObservableCollection<Game>(_allGames);
            EditCommand = new RelayCommand(EditGame);
            DeleteCommand = new RelayCommand(DeleteGame);
        }

        private IEnumerable<Game> LoadMockGames()
        {
            // Return a list of Game objects, not anonymous types
            return
            [
            new Game { Title = "Cyberpunk 2077", Platform = "Steam", PurchaseDate = "2023-12-10", Price = "$59.99" },
            new Game { Title = "Baldur's Gate 3", Platform = "Steam", PurchaseDate = "2023-08-15", Price = "$59.99" },
            new Game { Title = "Starfield", Platform = "Epic Games", PurchaseDate = "2023-09-06", Price = "$69.99" },
            new Game { Title = "Hogwarts Legacy", Platform = "Steam", PurchaseDate = "2023-02-10", Price = "$59.99" },
            new Game { Title = "Elden Ring", Platform = "Steam", PurchaseDate = "2022-02-25", Price = "$59.99" },
            new Game { Title = "God of War", Platform = "Epic Games", PurchaseDate = "2022-01-14", Price = "$49.99" },
            new Game { Title = "Spider-Man Remastered", Platform = "Steam", PurchaseDate = "2022-08-12", Price = "$59.99" },
            new Game { Title = "Oldschool Runescape bond", Platform = "Jagex", PurchaseDate = "2021-12-20", Price = "$14.99" }
            ];
        }

        private void FilterGames()
        {
            var filtered = string.IsNullOrWhiteSpace(SearchText)
                ? _allGames
                : _allGames.Where(g => g.Title.Contains(SearchText, System.StringComparison.OrdinalIgnoreCase)).ToList();

            Games.Clear();
            foreach (var game in filtered)
                Games.Add(game);

            OnPropertyChanged(nameof(GameCount));
            OnPropertyChanged(nameof(TotalValue));
        }

        private void EditGame(object parameter)
        {
            // Implement edit logic here
        }

        private void DeleteGame(object parameter)
        {
            // Implement delete logic here
        }

        public event PropertyChangedEventHandler? PropertyChanged; // Fix CS8612/CS8618: Nullable event
        protected void OnPropertyChanged(string name) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}