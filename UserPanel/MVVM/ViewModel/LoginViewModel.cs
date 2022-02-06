using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;

namespace UserPanel.MVVM.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public string Username { get; set; }

        private LoginModel _logModel;
        public LoginModel LogModel
        {
            get
            {
                return _logModel;
            }
            set
            {
                _logModel = value;
                OnPropertyChanged();
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        { 
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged();
            }
        }
        
        public RelayCommand Login { get; set; }
        public RelayCommand NavigateToRegister { get; set; }
        public LoginViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            LogModel = new LoginModel();

            NavigateToRegister = new RelayCommand(o => {
                navigator.NavigateTo<RegisterViewModel>();
            });

            Login = new RelayCommand(async o => {
                if (LogModel.Username.Length == 0 || LogModel.Password.Length == 0)
                {
                    ErrorMessage = "One or more fields are empty";
                }
                else
                {
                    ErrorModel errm = await authenticator.Login(LogModel);
                    if (authenticator.Authorized)
                    {
                        navigator.NavigateTo<UserPanelViewModel>();
                    }
                    else
                    {
                        ErrorMessage = errm?.Issue;
                    }

                }
            });
        }
    }
}
