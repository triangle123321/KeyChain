using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GameKeyManager.Assets.Throbber
{
    public partial class Throbber : UserControl
    {
        private Storyboard _spinStoryboard = null!; // Initialize with null-forgiving operator  

        public Throbber()
        {
            InitializeComponent();
            Loaded += SimpleThrobber_Loaded;
            Unloaded += SimpleThrobber_Unloaded;
        }

        private void SimpleThrobber_Loaded(object sender, RoutedEventArgs e)
        {
            StartAnimation();
        }

        private void SimpleThrobber_Unloaded(object sender, RoutedEventArgs e)
        {
            StopAnimation();
        }

        public void StartAnimation()
        {
            _spinStoryboard = (Storyboard)Resources["SpinStoryboard"];
            _spinStoryboard?.Begin();
        }

        public void StopAnimation()
        {
            _spinStoryboard?.Stop();
        }

        public static readonly DependencyProperty SizeProperty =
            DependencyProperty.Register("Size", typeof(double), typeof(Throbber),
                new PropertyMetadata(50.0, OnSizeChanged));

        public double Size
        {
            get { return (double)GetValue(SizeProperty); }
            set { SetValue(SizeProperty, value); }
        }

        private static void OnSizeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var throbber = (Throbber)d;
            throbber.Width = (double)e.NewValue;
            throbber.Height = (double)e.NewValue;
        }
    }
}