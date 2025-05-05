using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.RecipeModule.Models.StepParameter;

namespace RecipeApi.RecipeModule.Profiles;

public class StepParameterProfile : Profile
{
    public StepParameterProfile()
    {

        CreateMap<CreateStepParameterRequest, StepParameter>();

        CreateMap<StepParameter, StepParameterResponse>();
        CreateMap<StepParameter, StepParameterResponseSingle>();

        CreateMap<StepParameter, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.StepParameterTemplate.Name ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}