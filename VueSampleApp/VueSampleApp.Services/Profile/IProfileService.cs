using System.Collections.Generic;

namespace VueSampleApp.Services.Profile
{
    public interface IProfileService
    {
        List<Data.Models.Profile> GetAllProfiles();
        ServiceResponse<Data.Models.Profile> UpdateProfile(Data.Models.Profile profile);
        ServiceResponse<Data.Models.Profile> CreateProfile(Data.Models.Profile profile);
        Data.Models.Profile GetByProfileId(int id);
        ServiceResponse<bool> DeleteProfile(int id);
    }
}
