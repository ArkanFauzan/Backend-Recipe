using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.AccountModule.Models.Role;

namespace RecipeApi.AccountModule.Profiles;

public class RoleProfile : Profile
{
    public RoleProfile()
    {

        CreateMap<CreateRoleRequest, Role>();

        CreateMap<Role, RoleResponse>();
        CreateMap<Role, RoleResponseSingle>();

        CreateMap<Role, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.RoleName ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}