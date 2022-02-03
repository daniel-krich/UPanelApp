using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserPanel.Core;

namespace UserPanel.MVVM.Model
{
    public class UserModel
    {
        public string Username { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
    }
}
