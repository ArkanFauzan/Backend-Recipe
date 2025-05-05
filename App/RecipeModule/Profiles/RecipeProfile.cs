using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.Recipe;

namespace RecipeApi.RecipeModule.Profiles;

public class RecipeProfile : Profile
{
    public RecipeProfile()
    {

        CreateMap<CreateRecipeRequest, Recipe>();

        CreateMap<Recipe, RecipeResponse>();
        CreateMap<Recipe, RecipeResponseSingle>();

        CreateMap<Recipe, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.Name ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}