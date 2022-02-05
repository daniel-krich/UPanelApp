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
        public RelayCommand UpdatePassword { get; set; }
        public LoginViewModel(INavigator navigator, IAuthenticator authenticator)
        {

            Login = new RelayCommand(async o => {
                PasswordBox psd = o as PasswordBox;
                if (Username.Length == 0 || psd.Password.Length == 0)
                {
                    ErrorMessage = "One or more fields are empty";
                }
                else
                {
                    ErrorModel errm = await authenticator.Auth(Username, psd.Password);
                    if (authenticator.Authorized)
                    {
                        navigator.CurrentView = AppServices.ServiceProvider.GetRequiredService<UserPanelViewModel>();
                    }
                    else
                    {
                        ErrorMessage = errm.Issue;
                    }

                }
            });
        }
    }
}
