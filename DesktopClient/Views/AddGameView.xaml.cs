using System;
using System.Windows;
using System.Windows.Controls;

namespace GameKeyManager.Views
{
    public partial class AddGameView : UserControl
    {
        public event EventHandler GameSaved = delegate { }; // Initialize with an empty delegate
        public event EventHandler CancelRequested = delegate { }; // Initialize with an empty delegate

        public AddGameView()
        {
            InitializeComponent();
            ClearForm();
        }

        private void BtnSaveGame_Click(object sender, RoutedEventArgs e)
        {
            if (ValidateForm())
            {
                // TODO: Save game to database
                MessageBox.Show("Game saved successfully!", "Success",
                    MessageBoxButton.OK, MessageBoxImage.Information);

                ClearForm();
                GameSaved?.Invoke(this, EventArgs.Empty);
            }
        }

        private void BtnClearForm_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure you want to clear all fields?", "Clear Form",
                MessageBoxButton.YesNo, MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                ClearForm();
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            if (HasUnsavedChanges())
            {
                var result = MessageBox.Show("You have unsaved changes. Are you sure you want to cancel?",
                    "Unsaved Changes", MessageBoxButton.YesNo, MessageBoxImage.Question);

                if (result == MessageBoxResult.No)
                    return;
            }

            ClearForm();
            CancelRequested?.Invoke(this, EventArgs.Empty);
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(TxtGameTitle.Text))
            {
                MessageBox.Show("Please enter a game title.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtGameTitle.Focus();
                return false;
            }

            if (CmbPlatform.SelectedItem == null)
            {
                MessageBox.Show("Please select a platform.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CmbPlatform.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtProductKey.Text))
            {
                MessageBox.Show("Please enter a product key.", "Validation Error",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TxtProductKey.Focus();
                return false;
            }

            // Validate price format if entered
            if (!string.IsNullOrWhiteSpace(TxtPrice.Text))
            {
                if (!decimal.TryParse(TxtPrice.Text.Replace("$", ""), out _))
                {
                    MessageBox.Show("Please enter a valid price (e.g., 59.99).", "Validation Error",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                    TxtPrice.Focus();
                    return false;
                }
            }

            return true;
        }

        private bool HasUnsavedChanges()
        {
            return !string.IsNullOrWhiteSpace(TxtGameTitle.Text) ||
                   CmbPlatform.SelectedIndex != -1 ||
                   !string.IsNullOrWhiteSpace(TxtProductKey.Text) ||
                   !string.IsNullOrWhiteSpace(TxtPrice.Text) ||
                   DtPurchaseDate.SelectedDate.HasValue ||
                   !string.IsNullOrWhiteSpace(TxtNotes.Text);
        }

        public void ClearForm()
        {
            TxtGameTitle.Clear();
            CmbPlatform.SelectedIndex = -1;
            TxtProductKey.Clear();
            TxtPrice.Clear();
            DtPurchaseDate.SelectedDate = null;
            TxtNotes.Clear();

            // Set focus to first field
            TxtGameTitle.Focus();
        }

        // Public method to populate form for editing (future use)
        public void LoadGameData(object gameData)
        {
            // TODO: Implement when we have proper game model
            // This will be used for editing existing games
        }
    }
}