using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.DataType;

namespace RecipeApi.RecipeModule.Interfaces.Repositories;

public interface IDataTypeRepo
{
    Task<List<DataType>> GetAllDataTypes(ListFilter filter);
    Task<(List<DataType>, int, int)> GetPaginatedDataTypes(DataTypeFilter dataTypeFilter, int pageIndex, int pageSize);
    Task<DataType?> GetDataType(Guid id);
    Task<DataType?> GetFullDataType(Guid id);
    Task<bool> CheckDataTypeIdExist(Guid id);
    Task CreateDataType(DataType dataType);
    Task UpdateDataType(DataType dataType);
    Task DeleteDataType(DataType dataType);
    Task DeleteDataTypeRange(List<DataType> dataTypes);
}