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
        public UserModel User { get; set; }
        public bool Authorized { get; set; }

        public void Auth(string username, string password, out ErrorModel errorModel)
        {
            HttpClient request = new HttpClient();
            StringContent payload = new StringContent(JsonConvert.SerializeObject(new LoginModel { 
                Username = username,
                Password = password
            }), Encoding.UTF8, "application/json");
            HttpResponseMessage res = request.PostAsync("http://127.0.0.1/api/login", payload).Result;
            User = JsonConvert.DeserializeObject<UserModel>(res.Content.ReadAsStringAsync().Result);
            Authorized = User.Username == username && username.Length > 0 ? true : false;
            if (!Authorized)
                errorModel = JsonConvert.DeserializeObject<ErrorModel>(res.Content.ReadAsStringAsync().Result);
            else
                errorModel = new ErrorModel();

        }
    }
}
