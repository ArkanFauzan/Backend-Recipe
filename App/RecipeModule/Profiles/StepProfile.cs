using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.RecipeModule.Models.Step;

namespace RecipeApi.RecipeModule.Profiles;

public class StepProfile : Profile
{
    public StepProfile()
    {

        CreateMap<CreateStepRequest, Step>();

        CreateMap<Step, StepResponse>();
        CreateMap<Step, StepResponseSingle>();

        CreateMap<Step, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.Name ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}