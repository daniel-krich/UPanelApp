using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.Core;
using UserPanel.MVVM.ViewModel;

namespace UserPanel.Services
{
    public class Navigator : INavigator
    {
        private MainViewModel _mainViewModel;
        private IServiceProvider _serviceProvider;
        public Navigator(IServiceProvider serviceProvider, MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
            _serviceProvider = serviceProvider;
        }

        public void NavigateTo<T>()
        {
            _mainViewModel.CurrentView = _serviceProvider.GetRequiredService<T>();
        }
    }
}
