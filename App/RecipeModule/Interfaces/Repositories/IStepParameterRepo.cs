using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.StepParameter;

namespace RecipeApi.RecipeModule.Interfaces.Repositories;

public interface IStepParameterRepo
{
    Task<List<StepParameter>> GetAllStepParameters(ListFilter filter);
    Task<(List<StepParameter>, int, int)> GetPaginatedStepParameters(StepParameterFilter stepParameterFilter, int pageIndex, int pageSize);
    Task<StepParameter?> GetStepParameter(Guid id);
    Task<StepParameter?> GetFullStepParameter(Guid id);
    Task<bool> CheckStepParameterIdExist(Guid id);
    Task CreateStepParameter(StepParameter stepParameter);
    Task UpdateStepParameter(StepParameter stepParameter);
    Task DeleteStepParameter(StepParameter stepParameter);
    Task DeleteStepParameterRange(List<StepParameter> stepParameters);
}