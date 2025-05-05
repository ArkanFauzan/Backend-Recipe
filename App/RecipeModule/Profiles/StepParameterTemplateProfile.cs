using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.RecipeModule.Models.StepParameterTemplate;

namespace RecipeApi.RecipeModule.Profiles;

public class StepParameterTemplateProfile : Profile
{
    public StepParameterTemplateProfile()
    {

        CreateMap<CreateStepParameterTemplateRequest, StepParameterTemplate>();

        CreateMap<StepParameterTemplate, StepParameterTemplateResponse>();
        CreateMap<StepParameterTemplate, StepParameterTemplateResponseSingle>();

        CreateMap<StepParameterTemplate, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.Name ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}