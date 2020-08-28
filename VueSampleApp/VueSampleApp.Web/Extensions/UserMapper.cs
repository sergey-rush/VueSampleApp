using System;
using VueSampleApp.Data.Models;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Extensions
{
    public static class UserMapperExtensions
    {
        public static UserModel ToUserModel(this User user)
        {
            return new UserModel
            {
                Id = user.Id,
                AccountId = user.AccountId,
                ProfileId = user.ProfileId
            };
        }

        public static User ToUser(this UserModel model)
        {
            return new User
            {
                Id = model.Id,
                AccountId = model.AccountId,
                ProfileId = model.ProfileId
            };
        }
    }
}