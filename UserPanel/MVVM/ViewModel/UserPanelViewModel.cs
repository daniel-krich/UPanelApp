using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;

namespace UserPanel.MVVM.ViewModel
{
    public class UserPanelViewModel : BaseViewModel
    {
        private UserModel _currentUser;
        public UserModel CurrentUser {
            get
            {
                return _currentUser;
            }
            set
            {
                _currentUser = value;
                OnPropertyChanged();
            }
        }
        public RelayCommand GotoLogin { get; set; }
        public UserPanelViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            CurrentUser = authenticator.User;

            GotoLogin = new RelayCommand(o =>
            {
                authenticator.Authorized = false;
                authenticator.User = null;
                navigator.CurrentView = AppServices.ServiceProvider.GetRequiredService<LoginViewModel>();
            });
        }
    }
}
