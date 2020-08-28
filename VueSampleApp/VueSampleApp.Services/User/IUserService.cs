using System.Collections.Generic;

namespace VueSampleApp.Services.User
{
    public interface IUserService
    {
        List<Data.Models.User> GetAllUsers();
        ServiceResponse<Data.Models.User> UpdateUser(Data.Models.User account);
        ServiceResponse<Data.Models.User> CreateUser(Data.Models.User account);
        ServiceResponse<bool> DeleteUser(int id);
        Data.Models.User GetUserById(int id);
    }
}