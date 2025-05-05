using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Interfaces.Services;

public interface IStepParameterTemplateService
{
    Task<List<SelectDataResponse>> GetListStepParameterTemplate(ListFilter filter);
    Task<PaginatedResponse<StepParameterTemplateResponse>> GetPaginatedStepParameterTemplate(StepParameterTemplateFilter filter);
    Task<StepParameterTemplateResponseSingle> GetStepParameterTemplateById(Guid id);
    Task<StepParameterTemplateResponse> CreateStepParameterTemplate(CreateStepParameterTemplateRequest model);
    Task<StepParameterTemplateResponse> UpdateStepParameterTemplate(Guid id, UpdateStepParameterTemplateRequest model);
    Task DeleteStepParameterTemplate(Guid id);

}