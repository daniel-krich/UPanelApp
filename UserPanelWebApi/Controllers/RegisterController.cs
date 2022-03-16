using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserPanelWebApi.DataAccess;
using UserPanelWebApi.Entities;
using UserPanelWebApi.Models;

namespace UserPanelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly ILogger<RegisterController> _logger;
        private readonly QueryContext _queryContext;

        public RegisterController(ILogger<RegisterController> logger, QueryContext queryContext)
        {
            _logger = logger;
            _queryContext = queryContext;
        }

        [HttpPost]
        public async Task<string> Register([FromBody] RegisterModel registerModel)
        {
            try
            {
                EntityEntry<UserEntity> newUser = await _queryContext.Users.AddAsync(new UserEntity
                {
                    Username = registerModel.Username,
                    Password = registerModel.Password,
                    Email = registerModel.Email,
                    Description = registerModel.Description,
                    Age = registerModel.Age
                });

                await _queryContext.SaveChangesAsync();
                _logger.Log(LogLevel.Information, $"{newUser.Entity.Username} - New user created");
                return JsonConvert.SerializeObject(newUser.Entity);
            }
            catch (DbUpdateException)
            {
                return JsonConvert.SerializeObject(new ErrorModel(2, "Couldn't finish registration, username or email already in use."));
            }
        }
    }
}
