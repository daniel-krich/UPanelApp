using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.MVVM.Model;

namespace UserPanel.Services
{
    public interface IAuthenticator
    {
        UserModel User { get; set; }

        bool Authorized { get; set; }

        Task Auth(string username, string password);
    }
}
