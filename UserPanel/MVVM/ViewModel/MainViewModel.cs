using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;
using System.Runtime.CompilerServices;

namespace UserPanel.MVVM.ViewModel
{

    public class MainViewModel : BaseViewModel, INavigator
    {
        public string AppTitle
        {
            get
            {
                AutoUpdateProperty(200);
                if (_authenticator.Authorized)
                    return $"Current user: {_authenticator.User.Username}";
                else
                    return "My Simple MVVM app";
            }
        }

        public RelayCommand SetMainPage { get; set; }
        private object _currentView;
        private IAuthenticator _authenticator;
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel(IAuthenticator authenticator)
        {
            _authenticator = authenticator;
        }
    }
}
