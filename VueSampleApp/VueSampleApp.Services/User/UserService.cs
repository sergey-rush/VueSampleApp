using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using VueSampleApp.Data;

namespace VueSampleApp.Services.User
{
    public class UserService: IUserService
    {
        private readonly DataContext _db;
        private readonly ILogger<UserService> _logger;

        public UserService(DataContext dbContext, ILogger<UserService> logger)
        {
            _db = dbContext;
            _logger = logger;
        }

        public List<Data.Models.User> GetAllUsers()
        {
            return _db.Users.OrderBy(u=>u.Id).ToList();
        }

        public ServiceResponse<Data.Models.User> UpdateUser(Data.Models.User account)
        {
            throw new System.NotImplementedException();
        }

        public ServiceResponse<Data.Models.User> CreateUser(Data.Models.User user)
        {
            try
            {
                _db.Users.Add(user);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.User>
                {
                    IsSuccess = true,
                    Message = "New user added",
                    Time = DateTime.UtcNow,
                    Data = user
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.User>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = user
                };

            }
        }

        public ServiceResponse<bool> DeleteUser(int id)
        {
            var user = _db.Users.Find(id);
            var now = DateTime.UtcNow;

            if (user == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "User to delete not found!",
                    Data = false
                };
            }

            try
            {
                _db.Users.Remove(user);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "User deleted",
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

        public Data.Models.User GetUserById(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}