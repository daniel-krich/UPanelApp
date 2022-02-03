using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserPanelWebApi.Models;

namespace UserPanelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;

        private static UserModel[] Accounts { get; }

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        static LoginController()
        {
            Accounts = new UserModel[3];
            Accounts[0] = new UserModel
            {
                Username = "dan",
                Password = "228228",
                Email = "dan@walla.com",
                Description = "whassuuppp everybody",
                Age = 20
            };
            Accounts[1] = new UserModel
            {
                Username = "Daniel",
                Password = "123456789",
                Email = "Daniel@walla.com",
                Description = "this is a test to my super simple no db api",
                Age = 18
            };
            Accounts[2] = new UserModel
            {
                Username = "zogov",
                Password = "123456",
                Email = "zogov@walla.com",
                Description = "Hello world :)",
                Age = 28
            };
        }

        [HttpGet, HttpDelete, HttpPut]
        public string ErrHttpMethod()
        {
            _logger.Log(LogLevel.Warning, "Ilegal access to /api/login");
            return "Method error, only Post allowed.";
        }

        [HttpPost]
        public string LoginToAccount([FromBody] LoginModel loginModel)
        {
            for (int i = 0; i < Accounts.Length; i++)
            {
                if (Accounts[i].Username == loginModel.Username &&
                    Accounts[i].Password == loginModel.Password)
                {
                    _logger.Log(LogLevel.Information, $"{Accounts[i].Username} logged in.");
                    return JsonConvert.SerializeObject(Accounts[i]);
                }
            }
            _logger.Log(LogLevel.Warning, $"{loginModel.Username} tried to log in, but failed.");
            return JsonConvert.SerializeObject(new ErrorModel(1, "Username or password doesn't exists"));
        }
    }
}
