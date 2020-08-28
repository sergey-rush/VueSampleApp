using System;
using VueSampleApp.Data.Models;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Extensions
{
    public static class AccountExtensions
    {
        public static AccountModel ToAccountModel(this Account account)
        {
            return new AccountModel
            {
                Id = account.Id,
                Name = account.Name,
                Email = account.Email
            };
        }

        public static Account ToAccount(this AccountModel account)
        {
            return new Account
            {
                Id = account.Id,
                Name = account.Name,
                Email = account.Email
            };
        }
    }
}