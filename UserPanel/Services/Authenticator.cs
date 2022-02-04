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
        public UserModel User { get; set; }
        public bool Authorized { get; set; }

        private readonly IErrorHandler _errorHandler;

        public Authenticator(IErrorHandler errorHandler)
        {
            _errorHandler = errorHandler;
        }

        public async Task Auth(string username, string password)
        {
            try
            {
                HttpClient request = new HttpClient();
                StringContent payload = new StringContent(JsonConvert.SerializeObject(new LoginModel
                {
                    Username = username,
                    Password = password
                }), Encoding.UTF8, "application/json");
                HttpResponseMessage res = await request.PostAsync(LoginUrl, payload);
                User = JsonConvert.DeserializeObject<UserModel>(await res.Content.ReadAsStringAsync());
                Authorized = User.Username == username && username.Length > 0 ? true : false;
            }
            catch(Exception e)
            {
                _errorHandler.ErrorReport(e);
            }

        }
    }
}
