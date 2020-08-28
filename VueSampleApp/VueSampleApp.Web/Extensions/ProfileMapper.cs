using VueSampleApp.Data.Models;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Extensions
{
    public static class ProfileExtensions
    {
        public static ProfileModel ToProfileModel(this Profile profile)
        {
            return new ProfileModel
            {
                Id = profile.Id,
                FirstName = profile.FirstName,
                LastName = profile.LastName
            };
        }

        public static Profile ToProfile(this ProfileModel model)
        {
            return new Profile
            {
                Id = model.Id,
                DepartmentId = model.DepartmentModel.Id,
                FirstName = model.FirstName,
                LastName = model.LastName
            };
        }
    }
}
