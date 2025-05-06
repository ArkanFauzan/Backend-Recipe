using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Interfaces.Repositories;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;
using RecipeApi.AccountModule.Models.Account;

namespace RecipeApi.AccountModule.Repositories;

public class AccountRepo (
    AppDbContext context
    ) : IAccountRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<Account>> GetAllAccounts(ListFilter filter)
    {
        IQueryable<Account> query = _context.Accounts.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.FullName, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<Account> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getAccounts(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<Account>, int, int)> GetPaginatedAccounts(AccountFilter accountFilter, int pageIndex, int pageSize)
    {
        IQueryable<Account> query = _context.Accounts.AsQueryable();

        query = query.Include(x => x.Role);

        if (accountFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.FullName, $"%{accountFilter.query}%"));
        }

        query = accountFilter.order switch
        {
            AccountOrder.FullName => query.OrderBy(x => x.FullName),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<Account> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<Account?> GetAccount(Guid id)
    {
        return await _context.Accounts.Include(x => x.Role).FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<Account?> GetFullAccount(Guid id)
    {
        return await _context.Accounts.Include(x => x.Role).FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckAccountIdExist(Guid id)
    {
        return await _context.Accounts.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateAccount(Account account)
    {
        await _context.Accounts.AddAsync(account);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAccount(Account account)
    {
        _context.Accounts.Update(account);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAccount(Account account)
    {
        _context.Accounts.Remove(account);
        await _context.SaveChangesAsync();
    }

    private async Task<List<Account>> getAccounts(List<Guid> ids)
    {
        return await _context.Accounts.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}