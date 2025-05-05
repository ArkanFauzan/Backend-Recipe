using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.RecipeModule.Models.Recipe;
using RecipeApi.RecipeModule.Models.DataType;

namespace RecipeApi.RecipeModule.Profiles;

public class DataTypeProfile : Profile
{
    public DataTypeProfile()
    {

        CreateMap<CreateDataTypeRequest, DataType>();

        CreateMap<DataType, DataTypeResponse>();
        CreateMap<DataType, DataTypeResponseSingle>();

        CreateMap<DataType, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.Name ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}