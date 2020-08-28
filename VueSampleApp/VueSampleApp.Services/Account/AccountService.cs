using System;
using System.Collections.Generic;
using System.Linq;
using VueSampleApp.Data;

namespace VueSampleApp.Services.Account
{
    public class AccountService : IAccountService
    {
        private readonly DataContext _db;

        public AccountService(DataContext dbContext)
        {
            _db = dbContext;
        }
      
        public List<Data.Models.Account> GetAllAccounts()
        {
            return _db.Accounts.OrderBy(account => account.Name).ToList();
        }

        public ServiceResponse<Data.Models.Account> UpdateAccount(Data.Models.Account account)
        {
            throw new NotImplementedException();
        }

        public ServiceResponse<Data.Models.Account> CreateAccount(Data.Models.Account account)
        {
            try
            {
                _db.Accounts.Add(account);
                _db.SaveChanges();
                return new ServiceResponse<Data.Models.Account>
                {
                    IsSuccess = true,
                    Message = "New account added",
                    Time = DateTime.UtcNow,
                    Data = account
                };
            }
            catch (Exception e)
            {
                return new ServiceResponse<Data.Models.Account>
                {
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Time = DateTime.UtcNow,
                    Data = account
                };

            }
        }
       
        public ServiceResponse<bool> DeleteAccount(int id)
        {
            var account = _db.Accounts.Find(id);
            var now = DateTime.UtcNow;
            
            if (account == null)
            {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = "Account to delete not found!",
                    Data = false
                };
            }

            try {
                _db.Accounts.Remove(account);
                _db.SaveChanges();

                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = true,
                    Message = "Account deleted",
                    Data = true
                };

            }
            catch (Exception e) {
                return new ServiceResponse<bool>
                {
                    Time = now,
                    IsSuccess = false,
                    Message = e.StackTrace,
                    Data = false
                };

            }
        }
       
        public Data.Models.Account GetAccountById(int id)
        {
            return _db.Accounts.First(a => a.Id == id);
        }

    }
}
