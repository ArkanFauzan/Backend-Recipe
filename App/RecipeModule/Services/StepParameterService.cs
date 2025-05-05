
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.RecipeModule.Models.StepParameter;
using RecipeApi.Enums;
using System.Text.RegularExpressions;

namespace RecipeApi.RecipeModule.Services;

public class StepParameterService(
    IMapper mapper,
    IStepParameterTemplateRepo stepParameterTemplateRepo,
    IStepParameterRepo stepParameterRepo,
    IStepRepo stepRepo
) : IStepParameterService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IStepParameterTemplateRepo _stepParameterTemplateRepo = stepParameterTemplateRepo;
    private readonly IStepParameterRepo _stepParameterRepo = stepParameterRepo;
    private readonly IStepRepo _stepRepo = stepRepo;

    public async Task<List<SelectDataResponse>> GetListStepParameter(ListFilter filter)
    {
        List<StepParameter> stepParameters = await _stepParameterRepo.GetAllStepParameters(filter);

        return _mapper.Map<List<SelectDataResponse>>(stepParameters);
    }

    public async Task<PaginatedResponse<StepParameterResponse>> GetPaginatedStepParameter(StepParameterFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<StepParameter> result, int count, int totalPages) = await _stepParameterRepo.GetPaginatedStepParameters(filter, pageIndex, pageSize);

        return mappingStepParameterPaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<StepParameterResponseSingle> GetStepParameterById(Guid id)
    {
        StepParameter stepParameter = await getFullStepParameterById(id);
        return _mapper.Map<StepParameterResponseSingle>(stepParameter);
    }

    public async Task<StepParameterResponse> CreateStepParameter(CreateStepParameterRequest model)
    {
        // Validate parent
        if (!await _stepRepo.CheckStepIdExist(model.StepId))
        {
            throw new Exception("Step not found");
        }
        StepParameterTemplate stepParameterTemplate = await getStepParameterTemplate(model.StepParameterTemplateId);

        if (!isValidValue(model.Value, stepParameterTemplate.DataType))
        {
            throw new Exception("Value is not valid");
        }

        StepParameter stepParameter = _mapper.Map<StepParameter>(model);

        await _stepParameterRepo.CreateStepParameter(stepParameter);

        return _mapper.Map<StepParameterResponse>(stepParameter);
    }

    public async Task<StepParameterResponse> UpdateStepParameter(Guid id, UpdateStepParameterRequest model)
    {
        StepParameter stepParameter = await getStepParameter(id);

        // Validate parent
        StepParameterTemplate stepParameterTemplate = await getStepParameterTemplate(model.StepParameterTemplateId);

        if (!isValidValue(model.Value, stepParameterTemplate.DataType))
        {
            throw new Exception("Value is not valid");
        }
        
        stepParameter.StepParameterTemplateId = model.StepParameterTemplateId;
        stepParameter.Value = model.Value;
        stepParameter.Note = model.Note;

        await _stepParameterRepo.UpdateStepParameter(stepParameter);

        return _mapper.Map<StepParameterResponse>(stepParameter);
    }

    public async Task DeleteStepParameter(Guid id)
    {
        StepParameter stepParameter = await getStepParameter(id);

        await _stepParameterRepo.DeleteStepParameter(stepParameter);
    }

    /**
    * private methods
    */
    private PaginatedResponse<StepParameterResponse> mappingStepParameterPaginatedResponse(IEnumerable<StepParameter> stepParameters, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<StepParameterResponse> stepParameterPaginatedResponse = new PaginatedResponse<StepParameterResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<StepParameterResponse>>(stepParameters),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return stepParameterPaginatedResponse;
    }

    private async Task<StepParameter> getStepParameter(Guid id)
    {
        StepParameter stepParameter = await _stepParameterRepo.GetStepParameter(id) ?? throw new KeyNotFoundException("StepParameter Not Found");
        return stepParameter;
    }

    private async Task<StepParameter> getFullStepParameterById(Guid id)
    {
        StepParameter stepParameter = await _stepParameterRepo.GetFullStepParameter(id) ?? throw new KeyNotFoundException("StepParameter Not Found");
        return stepParameter;
    }

    private async Task<StepParameterTemplate> getStepParameterTemplate(Guid id)
    {
        StepParameterTemplate stepParameterTemplate = await _stepParameterTemplateRepo.GetStepParameterTemplate(id) ?? throw new KeyNotFoundException("StepParameterTemplate Not Found");
        return stepParameterTemplate;
    }

    private bool isValidValue(string? value, DataType dataType)
    {
        if (value == null) return true;

        // Validasi berdasarkan tipe
        var isValid = dataType.ParseType switch
        {
            ParseTypeEnum.FLOAT => float.TryParse(value, out _),
            ParseTypeEnum.INTEGER => int.TryParse(value, out _),
            ParseTypeEnum.BOOLEAN => bool.TryParse(value, out _),
            ParseTypeEnum.DATE => DateTime.TryParse(value, out _),
            ParseTypeEnum.TEXT => true,
            ParseTypeEnum.CUSTOM_REGEX => true, // langsung true, validasi regex di bawah
            _ => true
        };

        if (!isValid) return false;
        else if (dataType.ParseType == ParseTypeEnum.CUSTOM_REGEX && string.IsNullOrEmpty(dataType.CustomRegex)) return false;

        // Validasi tambahan menggunakan regex jika tersedia
        if (dataType.ParseType == ParseTypeEnum.CUSTOM_REGEX && !string.IsNullOrWhiteSpace(dataType.CustomRegex))
        {
            return Regex.IsMatch(value, dataType.CustomRegex);
        }

        return true;
    }

}