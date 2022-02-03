using System;
using System.Collections.Generic;
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
    public class LoginViewModel : ObservableObject
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
        public LoginViewModel(IAuthenticator authenticator)
        {

            Login = new RelayCommand(o => {
                PasswordBox psd = o as PasswordBox;
                if (Username.Length == 0 || psd.Password.Length == 0)
                {
                    ErrorMessage = "One or more fields are empty";
                }
                else
                {
                    ErrorModel errm;
                    authenticator.Auth(Username, psd.Password, out errm);

                    if(authenticator.Authorized)
                    {
                        ShellViewModelInstance.CurrentView = new UserPanelViewModel(authenticator);
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
