using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.DataType;
using RecipeApi.RecipeModule.Models.Step;
using RecipeApi.RecipeModule.Models.StepParameter;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.Helpers;

public static class SiteHelper
{
    public static int ValidatePageSize(int pageSize)
    {
        List<int> validPageSizes = new List<int>() { 10, 25, 50, 100, 200 };
        return validPageSizes.Contains(pageSize) ? pageSize : 10;
    }

    /// <summary>
    /// Parses a comma-separated string of GUIDs into a list of valid GUIDs.
    /// </summary>
    /// <param name="commaSeparatedGuids">A string containing GUIDs separated by commas.</param>
    /// <returns>A list of valid GUIDs parsed from the input string.</returns>
    public static List<Guid> ParseGuids(string commaSeparatedGuids)
    {
        if (string.IsNullOrEmpty(commaSeparatedGuids))
        {
            return [];
        }

        // Split the input string by commas to get individual GUID strings
        // Then attempt to parse each GUID string; if parsing fails, use Guid.Empty
        // After that filter out any invalid GUIDs (Guid.Empty)
        // Finally convert the filtered GUIDs into a list
        return commaSeparatedGuids
            .Split(',')
            .Select(guidString => Guid.TryParse(guidString, out var guid) ? guid : Guid.Empty)
            .Where(guid => guid != Guid.Empty)
            .ToList();
    }

    public static List<StepResponseSingle> BuildStepTree(List<Step> currentSteps, List<Step> allSteps)
    {
        return currentSteps
        .OrderBy(x => x.Order).ThenBy(x => x.Created)
        .Select(step => new StepResponseSingle
        {
            Id = step.Id,
            Name = step.Name,
            RecipeId = step.RecipeId,
            ParentId = step.ParentId,
            StepParameters = step.StepParameters.OrderBy(x => x.Created).Select(stepParameter => new StepParameterResponse
            {
                Id = stepParameter.Id,
                StepId = stepParameter.StepId,
                StepParameterTemplate = new StepParameterTemplateResponse
                {
                    Id = stepParameter.StepParameterTemplate.Id,
                    Name = stepParameter.StepParameterTemplate.Name,
                    DataType = new DataTypeResponse
                    {
                        Id = stepParameter.StepParameterTemplate.DataType.Id,
                        Name = stepParameter.StepParameterTemplate.DataType.Name,
                        ParseType = stepParameter.StepParameterTemplate.DataType.ParseType,
                        CustomRegex = stepParameter.StepParameterTemplate.DataType.CustomRegex
                    },
                    Description = stepParameter.StepParameterTemplate.Description
                },
                Value = stepParameter.Value,
                Note = stepParameter.Note
            }).ToList(),
            Children = BuildStepTree(allSteps.Where(s => s.ParentId == step.Id).ToList(), allSteps)
        })
        .ToList();
    }
}