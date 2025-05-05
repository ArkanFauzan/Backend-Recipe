using Microsoft.EntityFrameworkCore;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.Data;
using RecipeApi.RecipeModule.Models.DataType;

namespace RecipeApi.RecipeModule.Repositories;

public class DataTypeRepo (
    AppDbContext context
    ) : IDataTypeRepo
{
    public readonly AppDbContext _context = context;

    public async Task<List<DataType>> GetAllDataTypes(ListFilter filter)
    {
        IQueryable<DataType> query = _context.DataTypes.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Query))
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{filter.Query}%"));
        }

        if (filter.Limit > 0)
        {
            query = query.Take((int)filter.Limit);
        }

        List<DataType> types = await query.ToListAsync();

        if (!string.IsNullOrEmpty(filter.Includes))
        {
            List<Guid> guids = SiteHelper.ParseGuids(filter.Includes);

            types.AddRange(await getDataTypes(guids));
        }

        return types.Distinct().ToList();
    }

    public async Task<(List<DataType>, int, int)> GetPaginatedDataTypes(DataTypeFilter dataTypeFilter, int pageIndex, int pageSize)
    {
        IQueryable<DataType> query = _context.DataTypes.AsQueryable();

        if (dataTypeFilter.query != null)
        {
            query = query.Where(x => EF.Functions.Like(x.Name, $"%{dataTypeFilter.query}%"));
        }

        query = dataTypeFilter.order switch
        {
            DataTypeOrder.Name => query.OrderBy(x => x.Name),
            _ => query.OrderByDescending(x => x.Created)
        };

        List<DataType> result = await query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();
        int count = await query.CountAsync();
        int totalPages = (int)Math.Ceiling(count / (double)pageSize);

        return (result, count, totalPages);
    }

    public async Task<DataType?> GetDataType(Guid id)
    {
        return await _context.DataTypes.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<DataType?> GetFullDataType(Guid id)
    {
        return await _context.DataTypes.FirstOrDefaultAsync( x => x.Id == id);
    }

    public async Task<bool> CheckDataTypeIdExist(Guid id)
    {
        return await _context.DataTypes.AnyAsync(x => x.Id == id);
    }
    
    public async Task CreateDataType(DataType dataType)
    {
        await _context.DataTypes.AddAsync(dataType);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateDataType(DataType dataType)
    {
        _context.DataTypes.Update(dataType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDataType(DataType dataType)
    {
        _context.DataTypes.Remove(dataType);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteDataTypeRange(List<DataType> dataTypes)
    {
        _context.DataTypes.RemoveRange(dataTypes);
        await _context.SaveChangesAsync();
    }

    private async Task<List<DataType>> getDataTypes(List<Guid> ids)
    {
        return await _context.DataTypes.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}