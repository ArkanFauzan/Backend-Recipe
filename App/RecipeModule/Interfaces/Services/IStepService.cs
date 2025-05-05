using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Interfaces.Services;

public interface IStepService
{
    Task<List<SelectDataResponse>> GetListStep(ListFilter filter);
    Task<PaginatedResponse<StepResponse>> GetPaginatedStep(StepFilter filter);
    Task<StepResponseSingle> GetStepById(Guid id);
    Task<StepResponseSingle> GetStepByIdWithAllChildren(Guid id);
    Task<StepResponseSingle> GetStepByIdWithAllChildrenAndParameter(Guid id);
    Task<StepResponse> CreateStep(CreateStepRequest model);
    Task<StepResponse> UpdateStep(Guid id, UpdateStepRequest model);
    Task DeleteStep(Guid id);

}