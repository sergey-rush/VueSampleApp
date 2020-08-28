using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VueSampleApp.Services.Profile;
using VueSampleApp.Web.Extensions;
using VueSampleApp.Web.ViewModels;

namespace VueSampleApp.Web.Controllers
{
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IProfileService profileService;
        private readonly ILogger<ProfileController> _logger;

        public ProfileController(
            ILogger<ProfileController> logger,
            IProfileService profileService
            )
        {
            this.profileService = profileService;
            _logger = logger;
        }

        [HttpPost("/api/profile")]
        public ActionResult CreateProfile([FromBody] ProfileModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Creating a new profile");
            var profile = model.ToProfile();
            var newProfile = profileService.CreateProfile(profile);
            return Ok(newProfile);
        }

        [HttpGet("/api/profile")]
        public ActionResult GetProfiles()
        {
            _logger.LogInformation("Getting profiles");
            var profiles = profileService.GetAllProfiles();

            var profileModels = profiles
                .Select(p => new ProfileModel
                {
                    Id = p.Id,
                    FirstName = p.FirstName,
                    LastName = p.LastName,
                    DepartmentModel = p.Department.ToDepartmentModel()
                })
                .OrderByDescending(p => p.Id).ToList();

            return Ok(profileModels);
        }

        [HttpDelete("/api/profile/{id}")]
        public ActionResult DeleteProfile(int id)
        {
            _logger.LogInformation("Deleting a account");
            var response = profileService.DeleteProfile(id);
            return Ok(response);
        }
    }
}
