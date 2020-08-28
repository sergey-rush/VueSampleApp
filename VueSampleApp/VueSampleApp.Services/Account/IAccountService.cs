using System.Collections.Generic;

namespace VueSampleApp.Services.Account
{
    public interface IAccountService
    {
        List<Data.Models.Account> GetAllAccounts();
        ServiceResponse<Data.Models.Account> UpdateAccount(Data.Models.Account account);
        ServiceResponse<Data.Models.Account> CreateAccount(Data.Models.Account account);
        ServiceResponse<bool> DeleteAccount(int id);
        Data.Models.Account GetAccountById(int id);
    }
}
