using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueSampleApp.Services.User;
using VueSampleApp.Web.Extensions;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUserService userService;

        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            this.userService = userService;
            _logger = logger;
        }

        [HttpPost("/api/user")]
        public ActionResult CreateUser([FromBody] UserModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Creating a new user");
            var user = model.ToUser();
            var newUser = userService.CreateUser(user);
            return Ok(newUser);
        }

        [HttpGet("/api/user")]
        public ActionResult GetUsers()
        {
            _logger.LogInformation("Getting users");
            var accounts = userService.GetAllUsers();

            var accountModels = accounts
                .Select(account => new UserModel
                {
                    Id = account.Id,
                    AccountId = account.AccountId,
                    ProfileId = account.ProfileId
                })
                .OrderByDescending(u => u.Id)
                .ToList();

            return Ok(accountModels); 
        }

        [HttpDelete("/api/user/{id}")]
        public ActionResult DeleteUser(int id)
        {
            _logger.LogInformation("Deleting a user");
            var response = userService.DeleteUser(id);
            return Ok(response);
        }
    }
}
