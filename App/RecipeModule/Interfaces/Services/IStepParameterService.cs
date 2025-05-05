using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Models.StepParameter;

namespace RecipeApi.RecipeModule.Interfaces.Services;

public interface IStepParameterService
{
    Task<List<SelectDataResponse>> GetListStepParameter(ListFilter filter);
    Task<PaginatedResponse<StepParameterResponse>> GetPaginatedStepParameter(StepParameterFilter filter);
    Task<StepParameterResponseSingle> GetStepParameterById(Guid id);
    Task<StepParameterResponse> CreateStepParameter(CreateStepParameterRequest model);
    Task<StepParameterResponse> UpdateStepParameter(Guid id, UpdateStepParameterRequest model);
    Task DeleteStepParameter(Guid id);

}