using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Models.DataType;

namespace RecipeApi.RecipeModule.Interfaces.Services;

public interface IDataTypeService
{
    Task<List<SelectDataResponse>> GetListDataType(ListFilter filter);
    Task<PaginatedResponse<DataTypeResponse>> GetPaginatedDataType(DataTypeFilter filter);
    Task<DataTypeResponseSingle> GetDataTypeById(Guid id);
    Task<DataTypeResponse> CreateDataType(CreateDataTypeRequest model);
    Task<DataTypeResponse> UpdateDataType(Guid id, UpdateDataTypeRequest model);
    Task DeleteDataType(Guid id);

}