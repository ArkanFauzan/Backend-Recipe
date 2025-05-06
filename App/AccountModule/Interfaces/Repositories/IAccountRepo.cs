using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.AccountModule.Models.Account;

namespace RecipeApi.AccountModule.Interfaces.Repositories;

public interface IAccountRepo
{
    Task<List<Account>> GetAllAccounts(ListFilter filter);
    Task<(List<Account>, int, int)> GetPaginatedAccounts(AccountFilter accountFilter, int pageIndex, int pageSize);
    Task<Account?> GetAccount(Guid id);
    Task<Account?> GetFullAccount(Guid id);
    Task<bool> CheckAccountIdExist(Guid id);
    Task CreateAccount(Account account);
    Task UpdateAccount(Account account);
    Task DeleteAccount(Account account);
}