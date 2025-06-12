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
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}