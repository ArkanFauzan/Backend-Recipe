
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.AccountModule.Models.Account;
using RecipeApi.AccountModule.Interfaces.Repositories;

namespace RecipeApi.AccountModule.Services;

public class AccountService(
    IMapper mapper,
    IRoleRepo roleRepo,
    IAccountRepo accountRepo
) : IAccountService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IRoleRepo _roleRepo = roleRepo;
    private readonly IAccountRepo _accountRepo = accountRepo;

    public async Task<List<SelectDataResponse>> GetListAccount(ListFilter filter)
    {
        List<Account> accounts = await _accountRepo.GetAllAccounts(filter);

        return _mapper.Map<List<SelectDataResponse>>(accounts);
    }

    public async Task<PaginatedResponse<AccountResponse>> GetPaginatedAccount(AccountFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<Account> result, int count, int totalPages) = await _accountRepo.GetPaginatedAccounts(filter, pageIndex, pageSize);

        return mappingAccountPaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<AccountResponseSingle> GetAccountById(Guid id)
    {
        Account account = await getFullAccountById(id);
        return _mapper.Map<AccountResponseSingle>(account);
    }

    public async Task<AccountResponse> CreateAccount(CreateAccountRequest model)
    {
        if (!await _roleRepo.CheckRoleIdExist(model.RoleId))
        {
            throw new Exception("RoleId not found");
        }
            
        Account account = _mapper.Map<Account>(model);
        account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

        await _accountRepo.CreateAccount(account);

        return _mapper.Map<AccountResponse>(account);
    }

    public async Task<AccountResponse> UpdateAccount(Guid id, UpdateAccountRequest model)
    {
        if (!await _roleRepo.CheckRoleIdExist(model.RoleId))
        {
            throw new Exception("RoleId not found");
        }
        
        Account account = await getAccount(id);
        
        account.Username = model.Username;
        account.FullName = model.FullName;
        account.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);
        account.RoleId = model.RoleId;
        account.Email = model.Email;

        await _accountRepo.UpdateAccount(account);

        return _mapper.Map<AccountResponse>(account);
    }

    public async Task DeleteAccount(Guid id)
    {
        Account account = await getAccount(id);

        await _accountRepo.DeleteAccount(account);
    }

    /**
    * private methods
    */
    private PaginatedResponse<AccountResponse> mappingAccountPaginatedResponse(IEnumerable<Account> accounts, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<AccountResponse> accountPaginatedResponse = new PaginatedResponse<AccountResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<AccountResponse>>(accounts),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return accountPaginatedResponse;
    }

    private async Task<Account> getAccount(Guid id)
    {
        Account account = await _accountRepo.GetAccount(id) ?? throw new KeyNotFoundException("Account Not Found");
        return account;
    }

    private async Task<Account> getFullAccountById(Guid id)
    {
        Account account = await _accountRepo.GetFullAccount(id) ?? throw new KeyNotFoundException("Account Not Found");
        return account;
    }

}