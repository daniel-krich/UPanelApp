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

        private static UserEntity[] Accounts { get; }

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        static LoginController()
        {
            Accounts = new UserEntity[3];
            Accounts[0] = new UserEntity
            {
                Username = "dan",
                Password = "228228",
                Email = "dan@walla.com",
                Description = "whassuuppp everybody",
                Age = 20
            };
            Accounts[1] = new UserEntity
            {
                Username = "Daniel",
                Password = "123456789",
                Email = "Daniel@walla.com",
                Description = "this is a test to my super simple no db api",
                Age = 18
            };
            Accounts[2] = new UserEntity
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
        public string LoginToAccount([FromBody] LoginEntity loginModel)
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
            return JsonConvert.SerializeObject(new ErrorEntity(1, "Username or password doesn't exists"));
        }
    }
}
