using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueSampleApp.Services.Account;
using VueSampleApp.Web.Extensions;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Controllers
{
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IAccountService _accountService;

        public AccountController(ILogger<AccountController> logger, IAccountService accountService)
        {
            _accountService = accountService;
            _logger = logger;
        } 

        [HttpPost("/api/account")]
        public ActionResult CreateAccount([FromBody] AccountModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Creating a new account");
            var account = model.ToAccount();
            var newAccount = _accountService.CreateAccount(account);
            return Ok(newAccount);
        }

        [HttpGet("/api/account")]
        public ActionResult GetAccounts()
        {
            _logger.LogInformation("Getting accounts");
            var accounts = _accountService.GetAllAccounts();

            var accountModels = accounts
                .Select(account => new AccountModel
                {
                    Id = account.Id,
                    Name = account.Name,
                    Email = account.Email
                })
                .OrderByDescending(a => a.Id)
                .ToList();

            return Ok(accountModels); 
        }

        [HttpDelete("/api/account/{id}")]
        public ActionResult DeleteAccount(int id)
        {
            _logger.LogInformation("Deleting a account");
            var response = _accountService.DeleteAccount(id);
            return Ok(response);
        }
    }
}
