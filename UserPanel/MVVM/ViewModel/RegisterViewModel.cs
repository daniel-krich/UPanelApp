using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.Core;
using UserPanel.MVVM.Model;
using UserPanel.Services;

namespace UserPanel.MVVM.ViewModel
{
    public class RegisterViewModel : BaseViewModel
    {
        private RegisterModel _registerModel;
        public RegisterModel RegModel
        { 
            get
            {
                return _registerModel;
            }
            set
            {
                _registerModel = value;
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

        public RelayCommand NavigateToLogin { get; set; }
        public RelayCommand Register { get; set; }

        public RegisterViewModel(INavigator navigator, IAuthenticator authenticator)
        {
            RegModel = new RegisterModel();

            NavigateToLogin = new RelayCommand(o => {
                navigator.NavigateTo<LoginViewModel>();
            });

            Register = new RelayCommand(async o => {
                if (RegModel.Username.Length == 0 || RegModel.Password.Length == 0 ||
                    RegModel.Email.Length == 0 || RegModel.Description.Length == 0 ||
                    RegModel.Age == 0)
                {
                    ErrorMessage = "One or more fields are empty";
                }
                else
                {
                    ErrorModel errm = await authenticator.Register(RegModel);
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
