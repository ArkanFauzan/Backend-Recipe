using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Interfaces.Repositories;

public interface IStepRepo
{
    Task<List<Step>> GetAllSteps(ListFilter filter);
    Task<(List<Step>, int, int)> GetPaginatedSteps(StepFilter stepFilter, int pageIndex, int pageSize);
    Task<List<Step>> GetAllStepChildren(Guid recipeId, int startDepth);
    Task<List<Step>> GetStepDirectChildren(Guid recipeId, Guid? parentId);
    Task<List<Step>> GetAllStepChildrenWithParameter(Guid recipeId, int startDepth);
    Task<List<Step>> GetStepDirectChildrenWithParameter(Guid stepId);
    Task<Step?> GetStep(Guid id);
    Task<Step?> GetFullStep(Guid id);
    Task<bool> CheckStepIdExist(Guid id);
    Task CreateStep(Step step);
    Task UpdateStep(Step step);
    Task UpdateStepRange(List<Step> steps);
    Task DeleteStep(Step step);
    Task DeleteStepRange(List<Step> steps);
}