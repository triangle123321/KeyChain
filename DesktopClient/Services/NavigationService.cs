using GameKeyManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace GameKeyManager.Services
{
    public class NavigationService : INavigationService
    {
        private readonly MainWindowViewModel _mainWindowViewModel;
        private readonly Dictionary<Type, Func<object>> _factories = [];

        public NavigationService(MainWindowViewModel mainWindowViewModel)
        {
            _mainWindowViewModel = mainWindowViewModel;
        }
        public void Register<TViewModel>(Func<TViewModel> factory) where TViewModel : class
        {
            _factories[typeof(TViewModel)] = () => factory();
        }

        public void NavigateTo<TViewModel>() where TViewModel : class
        {
            if (_factories.TryGetValue(typeof(TViewModel), out var factory))
            {
                _mainWindowViewModel.CurrentViewModel = factory();
            }
            else
            {
                // Fallback to parameterless constructor if no factory registered
                _mainWindowViewModel.CurrentViewModel = Activator.CreateInstance<TViewModel>();
            }
        }
    }
}
