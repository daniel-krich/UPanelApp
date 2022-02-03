using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;

namespace UserPanel.MVVM.ViewModel
{
    public class UserPanelViewModel : ObservableObject
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
        public UserPanelViewModel(IAuthenticator authenticator)
        {
            if(authenticator.Authorized)
                CurrentUser = authenticator.User;
            else
                ShellViewModelInstance.CurrentView = new LoginViewModel(new Authenticator());

            GotoLogin = new RelayCommand(o =>
            {
                ShellViewModelInstance.CurrentView = new LoginViewModel(new Authenticator());
            });
        }
    }
}
