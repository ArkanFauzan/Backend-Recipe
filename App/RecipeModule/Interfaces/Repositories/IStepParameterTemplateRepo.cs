using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Interfaces.Repositories;

public interface IStepParameterTemplateRepo
{
    Task<List<StepParameterTemplate>> GetAllStepParameterTemplates(ListFilter filter);
    Task<(List<StepParameterTemplate>, int, int)> GetPaginatedStepParameterTemplates(StepParameterTemplateFilter stepParameterTemplateFilter, int pageIndex, int pageSize);
    Task<StepParameterTemplate?> GetStepParameterTemplate(Guid id);
    Task<StepParameterTemplate?> GetFullStepParameterTemplate(Guid id);
    Task<bool> CheckStepParameterTemplateIdExist(Guid id);
    Task CreateStepParameterTemplate(StepParameterTemplate stepParameterTemplate);
    Task UpdateStepParameterTemplate(StepParameterTemplate stepParameterTemplate);
    Task DeleteStepParameterTemplate(StepParameterTemplate stepParameterTemplate);
    Task DeleteStepParameterTemplateRange(List<StepParameterTemplate> stepParameterTemplates);
}