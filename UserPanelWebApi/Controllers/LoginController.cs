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

        public LoginController(ILogger<LoginController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public string Get([FromBody] LoginModel loginModel)
        {
            UserModel[] accounts = new UserModel[3];
            accounts[0] = new UserModel {
                Username = "dan",
                Password = "228228",
                Email = "dan@walla.com",
                Description = "whassuuppp everybody",
                Age = 20
            };
            accounts[1] = new UserModel
            {
                Username = "Daniel",
                Password = "123456789",
                Email = "Daniel@walla.com",
                Description = "this is a test to my super simple no db api",
                Age = 18
            };
            accounts[2] = new UserModel
            {
                Username = "zogov",
                Password = "123456",
                Email = "zogov@walla.com",
                Description = "Hello world :)",
                Age = 28
            };

            for (int i = 0; i < accounts.Length; i++)
            {
                if (accounts[i].Username == loginModel.Username &&
                    accounts[i].Password == loginModel.Password)
                {
                    _logger.Log(LogLevel.Information, $"{accounts[i].Username} logged in.");
                    return JsonConvert.SerializeObject(accounts[i]);
                }
            }
            _logger.Log(LogLevel.Warning, $"{loginModel.Username} tried to log in, but failed.");
            return JsonConvert.SerializeObject(new ErrorModel(1, "Username or password doesn't exists"));
        }
    }
}
