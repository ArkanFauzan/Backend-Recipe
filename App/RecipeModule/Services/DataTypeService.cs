
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.RecipeModule.Models.DataType;
using RecipeApi.Enums;

namespace RecipeApi.RecipeModule.Services;

public class DataTypeService(
    IMapper mapper,
    IRecipeRepo recipeRepo,
    IDataTypeRepo dataTypeRepo
) : IDataTypeService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IRecipeRepo _recipeRepo = recipeRepo;
    private readonly IDataTypeRepo _dataTypeRepo = dataTypeRepo;

    public async Task<List<SelectDataResponse>> GetListDataType(ListFilter filter)
    {
        List<DataType> dataTypes = await _dataTypeRepo.GetAllDataTypes(filter);

        return _mapper.Map<List<SelectDataResponse>>(dataTypes);
    }

    public async Task<PaginatedResponse<DataTypeResponse>> GetPaginatedDataType(DataTypeFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<DataType> result, int count, int totalPages) = await _dataTypeRepo.GetPaginatedDataTypes(filter, pageIndex, pageSize);

        return mappingDataTypePaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<DataTypeResponseSingle> GetDataTypeById(Guid id)
    {
        DataType dataType = await getFullDataTypeById(id);
        return _mapper.Map<DataTypeResponseSingle>(dataType);
    }

    public async Task<DataTypeResponse> CreateDataType(CreateDataTypeRequest model)
    {
        if (model.ParseType == ParseTypeEnum.CUSTOM_REGEX && string.IsNullOrEmpty(model.CustomRegex))
        {
            throw new Exception("CustomRegex field is required");
        }

        if (model.ParseType != ParseTypeEnum.CUSTOM_REGEX)
        {
            model.CustomRegex = "";
        }

        DataType dataType = _mapper.Map<DataType>(model);

        await _dataTypeRepo.CreateDataType(dataType);

        return _mapper.Map<DataTypeResponse>(dataType);
    }

    public async Task<DataTypeResponse> UpdateDataType(Guid id, UpdateDataTypeRequest model)
    {
        if (model.ParseType == ParseTypeEnum.CUSTOM_REGEX && string.IsNullOrEmpty(model.CustomRegex))
        {
            throw new Exception("CustomRegex field is required");
        }

        if (model.ParseType != ParseTypeEnum.CUSTOM_REGEX)
        {
            model.CustomRegex = "";
        }

        DataType dataType = await getDataType(id);
        
        dataType.Name = model.Name;
        dataType.ParseType = model.ParseType;
        dataType.CustomRegex = model.CustomRegex;

        await _dataTypeRepo.UpdateDataType(dataType);

        return _mapper.Map<DataTypeResponse>(dataType);
    }

    public async Task DeleteDataType(Guid id)
    {
        DataType dataType = await getDataType(id);

        await _dataTypeRepo.DeleteDataType(dataType);
    }

    /**
    * private methods
    */
    private PaginatedResponse<DataTypeResponse> mappingDataTypePaginatedResponse(IEnumerable<DataType> dataTypes, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<DataTypeResponse> dataTypePaginatedResponse = new PaginatedResponse<DataTypeResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<DataTypeResponse>>(dataTypes),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return dataTypePaginatedResponse;
    }

    private async Task<DataType> getDataType(Guid id)
    {
        DataType dataType = await _dataTypeRepo.GetDataType(id) ?? throw new KeyNotFoundException("DataType Not Found");
        return dataType;
    }

    private async Task<DataType> getFullDataTypeById(Guid id)
    {
        DataType dataType = await _dataTypeRepo.GetFullDataType(id) ?? throw new KeyNotFoundException("DataType Not Found");
        return dataType;
    }

}