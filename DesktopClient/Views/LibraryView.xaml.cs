using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace GameKeyManager.Views
{
    public partial class LibraryView : UserControl
    {
        public LibraryView()
        {
            InitializeComponent();
            LoadMockData();
        }

        private void TxtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            // TODO: Implement search functionality
            var searchText = TxtSearch.Text;
            // Filter the games based on search text
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag != null)
            {
                // TODO: Implement edit functionality
                MessageBox.Show($"Edit game functionality will be implemented later.", "Info",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.Tag != null)
            {
                var result = MessageBox.Show("Are you sure you want to delete this game?", "Confirm Delete",
                    MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    // TODO: Implement delete functionality
                    MessageBox.Show("Delete functionality will be implemented later.", "Info",
                        MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }

        // Mock Data for Testing UI
        private void LoadMockData()
        {
            var mockGames = new[]
            {
                new { Title = "Cyberpunk 2077", Platform = "Steam", PurchaseDate = "2023-12-10", Price = "$59.99" },
                new { Title = "Baldur's Gate 3", Platform = "Steam", PurchaseDate = "2023-08-15", Price = "$59.99" },
                new { Title = "Starfield", Platform = "Epic Games", PurchaseDate = "2023-09-06", Price = "$69.99" },
                new { Title = "Hogwarts Legacy", Platform = "Steam", PurchaseDate = "2023-02-10", Price = "$59.99" },
                new { Title = "Elden Ring", Platform = "Steam", PurchaseDate = "2022-02-25", Price = "$59.99" },
                new { Title = "God of War", Platform = "Epic Games", PurchaseDate = "2022-01-14", Price = "$49.99" },
                new { Title = "Spider-Man Remastered", Platform = "Steam", PurchaseDate = "2022-08-12", Price = "$59.99" }
            };

            GameDataGrid.ItemsSource = mockGames;
            TxtGameCount.Text = $"{mockGames.Length} Games";

            // Calculate total value (remove $ and sum)
            var total = mockGames.Sum(g => decimal.Parse(g.Price.Replace("$", "")));
            TxtTotalValue.Text = $"Total Value: ${total:F2}";
        }

        // Public method to refresh data (will be called from MainWindow)
        public void RefreshData()
        {
            LoadMockData();
        }
    }
}