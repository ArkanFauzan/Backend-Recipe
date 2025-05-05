
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Services;

public class StepService(
    IMapper mapper,
    IRecipeRepo recipeRepo,
    IStepRepo stepRepo
) : IStepService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IRecipeRepo _recipeRepo = recipeRepo;
    private readonly IStepRepo _stepRepo = stepRepo;

    public async Task<List<SelectDataResponse>> GetListStep(ListFilter filter)
    {
        List<Step> steps = await _stepRepo.GetAllSteps(filter);

        return _mapper.Map<List<SelectDataResponse>>(steps);
    }

    public async Task<PaginatedResponse<StepResponse>> GetPaginatedStep(StepFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<Step> result, int count, int totalPages) = await _stepRepo.GetPaginatedSteps(filter, pageIndex, pageSize);

        return mappingStepPaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<StepResponseSingle> GetStepById(Guid id)
    {
        Step step = await getFullStepById(id);
        StepResponseSingle result = _mapper.Map<StepResponseSingle>(step);

        List<Step> allSteps = await _stepRepo.GetAllStepChildren(step.RecipeId, step.Depth + 1);

        result.Children = SiteHelper.BuildStepTree(allSteps.Where(x => x.ParentId == step.Id).ToList(), allSteps);

        return result;
    }

    public async Task<StepResponse> CreateStep(CreateStepRequest model)
    {
        int depth = 1;

        // Validate ParentId and RecipeId
        if (model.ParentId != null)
        {
            Step ParentStep = await getStep((Guid)model.ParentId);
            model.RecipeId = ParentStep.RecipeId; // use from ParentStep Recipe Id

            depth = ParentStep.Depth + 1;
        }
        else {

            if (model.RecipeId == null)
            {
                throw new Exception("RecipeId is required");
            }

            if (!await _recipeRepo.CheckRecipeIdExist((Guid)model.RecipeId))
            {
                throw new Exception("RecipeId not found");
            }
        }

        Step step = _mapper.Map<Step>(model);
        step.Depth = depth;

        await _stepRepo.CreateStep(step);

        return _mapper.Map<StepResponse>(step);
    }

    public async Task<StepResponse> UpdateStep(Guid id, UpdateStepRequest model)
    {
        Step step = await getStep(id);
        
        step.Name = model.Name;

        await _stepRepo.UpdateStep(step);

        return _mapper.Map<StepResponse>(step);
    }

    public async Task DeleteStep(Guid id)
    {
        Step step = await getStep(id);

        // delete all child
        List<Step> directChildren = await _stepRepo.GetStepDirectChildren(id);
        foreach (var child in directChildren)
        {
            await DeleteStep(child.Id);
        }

        await _stepRepo.DeleteStep(step);
    }

    /**
    * private methods
    */
    private PaginatedResponse<StepResponse> mappingStepPaginatedResponse(IEnumerable<Step> steps, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<StepResponse> stepPaginatedResponse = new PaginatedResponse<StepResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<StepResponse>>(steps),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return stepPaginatedResponse;
    }

    private async Task<Step> getStep(Guid id)
    {
        Step step = await _stepRepo.GetStep(id) ?? throw new KeyNotFoundException("Step Not Found");
        return step;
    }

    private async Task<Step> getFullStepById(Guid id)
    {
        Step step = await _stepRepo.GetFullStep(id) ?? throw new KeyNotFoundException("Step Not Found");
        return step;
    }

}