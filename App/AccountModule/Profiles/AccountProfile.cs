using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.AccountModule.Models.Account;

namespace RecipeApi.AccountModule.Profiles;

public class AccountProfile : Profile
{
    public AccountProfile()
    {

        CreateMap<CreateAccountRequest, Account>();

        CreateMap<Account, AccountResponse>();
        CreateMap<Account, AccountResponseSingle>();

        CreateMap<Account, SelectDataResponse>()
            .ForMember(dest =>
                dest.Label,
                opt => opt.MapFrom( src => src.FullName ))
            .ForMember(dest =>
                dest.Value,
                opt => opt.MapFrom( src => src.Id ));

    }
}