using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Models.Account;

namespace RecipeApi.AccountModule.Interfaces.Services;

public interface IAccountService
{
    Task<List<SelectDataResponse>> GetListAccount(ListFilter filter);
    Task<PaginatedResponse<AccountResponse>> GetPaginatedAccount(AccountFilter filter);
    Task<AccountResponseSingle> GetAccountById(Guid id);
    Task<AccountResponse> CreateAccount(CreateAccountRequest model);
    Task<AccountResponse> UpdateAccount(Guid id, UpdateAccountRequest model);
    Task DeleteAccount(Guid id);

}