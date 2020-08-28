using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using VueSampleApp.Data;

namespace VueSampleApp.Services.Profile
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext _db;
        private readonly ILogger<ProfileService> _logger;

        public ProfileService(DataContext dbContext, ILogger<ProfileService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        public List<Data.Models.Profile> GetAllProfiles()
        {
            return _db.Profiles.Include(pi => pi.Department).ToList();
        }

        public Data.Models.Profile GetByProfileId(int id)
        {
            return _db.Profiles.Include(pi => pi.Department).FirstOrDefault(pi => pi.Id == id);
        }

        public ServiceResponse<Data.Models.Profile> UpdateProfile(Data.Models.Profile profile)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Data.Models.Profile> CreateProfile(Data.Models.Profile profile)
        {
            try
            {
                _db.Profiles.Add(profile);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Profile>
                {
                    IsSuccess = true,
                    Message = "New profile added",
                    Time = DateTime.UtcNow,
                    Data = profile
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Profile>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = profile
                };
            }
        }

        public ServiceResponse<bool> DeleteProfile(int id)
        {
            var profile = _db.Profiles.Find(id);
            var now = DateTime.UtcNow;

            if (profile == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Profile to delete not found!",
                    Data = false
                };
            }

            try
            {
                _db.Profiles.Remove(profile);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Profile deleted",
                    Data = true
                };

            }
            catch (Exception e)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };

            }
        }
    }
}
