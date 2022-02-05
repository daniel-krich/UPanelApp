using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using UserPanel.MVVM.Model;
using Newtonsoft.Json;

namespace UserPanel.Services
{
    public class Authenticator : IAuthenticator
    {
        private static string LoginUrl { get; } = "http://127.0.0.1/api/login";
        private static string RegisterUrl { get; } = "http://127.0.0.1/api/register";
        public UserModel User { get; set; }
        public bool Authorized { get; set; }

        private readonly IErrorHandler _errorHandler;
        private readonly INavigator _navigator;

        public Authenticator(INavigator navigator, IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
            _navigator = navigator;
        }

        public async Task<ErrorModel> Login(LoginModel loginModel)
        {
            try
            {
                HttpClient request = new HttpClient();
                StringContent payload = new StringContent(JsonConvert.SerializeObject(loginModel), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await request.PostAsync(LoginUrl, payload);
                User = JsonConvert.DeserializeObject<UserModel>(await res.Content.ReadAsStringAsync());
                Authorized = User.Username == loginModel.Username && loginModel.Username.Length > 0 ? true : false;

                if (Authorized)
                    _navigator.SetWindowTitle($"Current user: {User.Username}");

                ErrorModel errm = JsonConvert.DeserializeObject<ErrorModel>(await res.Content.ReadAsStringAsync());
                return errm;
            }
            catch(Exception e)
            {
                _errorHandler.ErrorReport(e);
                return new ErrorModel(-1, "Request timeout error, network issue.");
            }

        }

        public async Task<ErrorModel> Register(RegisterModel registerModel)
        {
            try
            {
                HttpClient request = new HttpClient();
                StringContent payload = new StringContent(JsonConvert.SerializeObject(registerModel), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await request.PostAsync(RegisterUrl, payload);
                User = JsonConvert.DeserializeObject<UserModel>(await res.Content.ReadAsStringAsync());
                Authorized = User.Username == registerModel.Username && registerModel.Username.Length > 0 ? true : false;

                if (Authorized)
                    _navigator.SetWindowTitle($"Current user: {User.Username}");

                ErrorModel errm = JsonConvert.DeserializeObject<ErrorModel>(await res.Content.ReadAsStringAsync());
                return errm;
            }
            catch (Exception e)
            {
                _errorHandler.ErrorReport(e);
                return new ErrorModel(-1, "Critical error");
            }

        }

        public void Logout()
        {
            User = null;
            Authorized = false;
            _navigator.SetWindowTitle("My simple MVVM app");
        }
    }
}
