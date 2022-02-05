using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using UserPanelWebApi.Models;
using UserPanelWebApi.Entities;
using UserPanelWebApi.DataAccess;
using Microsoft.EntityFrameworkCore;

namespace UserPanelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILogger<LoginController> _logger;
        private readonly QueryContext _queryContext;

        public LoginController(ILogger<LoginController> logger, QueryContext queryContext)
        {
            _logger = logger;
            _queryContext = queryContext;
        }

        [HttpGet, HttpDelete, HttpPut]
        public string ErrHttpMethod()
        {
            _logger.Log(LogLevel.Warning, "Ilegal access to /api/login");
            return "Method error, only Post allowed.";
        }

        [HttpPost]
        public async Task<string> Login([FromBody] LoginModel loginModel)
        {
            UserEntity user = await _queryContext.Users.FirstOrDefaultAsync(i => i.Username == loginModel.Username && i.Password == loginModel.Password);
            if(user is not null)
            {
                _logger.Log(LogLevel.Information, $"{user.Username} logged in.");
                return JsonConvert.SerializeObject(user);
            }
            _logger.Log(LogLevel.Warning, $"{loginModel.Username} tried to log in, but failed.");
            return JsonConvert.SerializeObject(new ErrorModel(1, "Username or password doesn't exists"));
        }
    }
}
