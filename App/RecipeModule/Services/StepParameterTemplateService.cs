
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Services;

public class StepParameterTemplateService(
    IMapper mapper,
    IDataTypeRepo dataTypeRepo,
    IStepParameterTemplateRepo stepParameterTemplateRepo
) : IStepParameterTemplateService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IDataTypeRepo _dataTypeRepo = dataTypeRepo;
    private readonly IStepParameterTemplateRepo _stepParameterTemplateRepo = stepParameterTemplateRepo;

    public async Task<List<SelectDataResponse>> GetListStepParameterTemplate(ListFilter filter)
    {
        List<StepParameterTemplate> stepParameterTemplates = await _stepParameterTemplateRepo.GetAllStepParameterTemplates(filter);

        return _mapper.Map<List<SelectDataResponse>>(stepParameterTemplates);
    }

    public async Task<PaginatedResponse<StepParameterTemplateResponse>> GetPaginatedStepParameterTemplate(StepParameterTemplateFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<StepParameterTemplate> result, int count, int totalPages) = await _stepParameterTemplateRepo.GetPaginatedStepParameterTemplates(filter, pageIndex, pageSize);

        return mappingStepParameterTemplatePaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<StepParameterTemplateResponseSingle> GetStepParameterTemplateById(Guid id)
    {
        StepParameterTemplate stepParameterTemplate = await getFullStepParameterTemplateById(id);
        return _mapper.Map<StepParameterTemplateResponseSingle>(stepParameterTemplate);
    }

    public async Task<StepParameterTemplateResponse> CreateStepParameterTemplate(CreateStepParameterTemplateRequest model)
    {
        if (!await _dataTypeRepo.CheckDataTypeIdExist(model.DataTypeId))
        {
            throw new Exception("DataTypeId not found");
        }

        StepParameterTemplate stepParameterTemplate = _mapper.Map<StepParameterTemplate>(model);

        await _stepParameterTemplateRepo.CreateStepParameterTemplate(stepParameterTemplate);

        return _mapper.Map<StepParameterTemplateResponse>(stepParameterTemplate);
    }

    public async Task<StepParameterTemplateResponse> UpdateStepParameterTemplate(Guid id, UpdateStepParameterTemplateRequest model)
    {
        if (!await _dataTypeRepo.CheckDataTypeIdExist(model.DataTypeId))
        {
            throw new Exception("DataTypeId not found");
        }

        StepParameterTemplate stepParameterTemplate = await getStepParameterTemplate(id);
        
        stepParameterTemplate.Name = model.Name;
        stepParameterTemplate.DataTypeId = model.DataTypeId;
        stepParameterTemplate.Description = model.Description;

        await _stepParameterTemplateRepo.UpdateStepParameterTemplate(stepParameterTemplate);

        return _mapper.Map<StepParameterTemplateResponse>(stepParameterTemplate);
    }

    public async Task DeleteStepParameterTemplate(Guid id)
    {
        StepParameterTemplate stepParameterTemplate = await getStepParameterTemplate(id);

        await _stepParameterTemplateRepo.DeleteStepParameterTemplate(stepParameterTemplate);
    }

    /**
    * private methods
    */
    private PaginatedResponse<StepParameterTemplateResponse> mappingStepParameterTemplatePaginatedResponse(IEnumerable<StepParameterTemplate> stepParameterTemplates, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<StepParameterTemplateResponse> stepParameterTemplatePaginatedResponse = new PaginatedResponse<StepParameterTemplateResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<StepParameterTemplateResponse>>(stepParameterTemplates),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return stepParameterTemplatePaginatedResponse;
    }

    private async Task<StepParameterTemplate> getStepParameterTemplate(Guid id)
    {
        StepParameterTemplate stepParameterTemplate = await _stepParameterTemplateRepo.GetStepParameterTemplate(id) ?? throw new KeyNotFoundException("StepParameterTemplate Not Found");
        return stepParameterTemplate;
    }

    private async Task<StepParameterTemplate> getFullStepParameterTemplateById(Guid id)
    {
        StepParameterTemplate stepParameterTemplate = await _stepParameterTemplateRepo.GetFullStepParameterTemplate(id) ?? throw new KeyNotFoundException("StepParameterTemplate Not Found");
        return stepParameterTemplate;
    }

}