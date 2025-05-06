
using AutoMapper;
using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Interfaces.Services;
using RecipeApi.Entities;
using RecipeApi.Helpers;
using RecipeApi.AccountModule.Models.Role;
using RecipeApi.AccountModule.Interfaces.Repositories;

namespace RecipeApi.AccountModule.Services;

public class RoleService(
    IMapper mapper,
    IRoleRepo roleRepo
) : IRoleService 
{
    private readonly IMapper _mapper = mapper;
    private readonly IRoleRepo _roleRepo = roleRepo;

    public async Task<List<SelectDataResponse>> GetListRole(ListFilter filter)
    {
        List<Role> roles = await _roleRepo.GetAllRoles(filter);

        return _mapper.Map<List<SelectDataResponse>>(roles);
    }

    public async Task<PaginatedResponse<RoleResponse>> GetPaginatedRole(RoleFilter filter)
    {
        int pageSize = SiteHelper.ValidatePageSize(filter.pageSize);
        int pageIndex = filter.page > 1 ? filter.page : 1;

        (List<Role> result, int count, int totalPages) = await _roleRepo.GetPaginatedRoles(filter, pageIndex, pageSize);

        return mappingRolePaginatedResponse(result, pageIndex, totalPages, count);
    }

    public async Task<RoleResponseSingle> GetRoleById(Guid id)
    {
        Role role = await getFullRoleById(id);
        return _mapper.Map<RoleResponseSingle>(role);
    }

    public async Task<RoleResponse> CreateRole(CreateRoleRequest model)
    {
        Role role = _mapper.Map<Role>(model);

        await _roleRepo.CreateRole(role);

        return _mapper.Map<RoleResponse>(role);
    }

    public async Task<RoleResponse> UpdateRole(Guid id, UpdateRoleRequest model)
    {
        Role role = await getRole(id);
        
        role.RoleName = model.RoleName;
        role.Description = model.Description;

        await _roleRepo.UpdateRole(role);

        return _mapper.Map<RoleResponse>(role);
    }

    public async Task DeleteRole(Guid id)
    {
        Role role = await getRole(id);

        await _roleRepo.DeleteRole(role);
    }

    /**
    * private methods
    */
    private PaginatedResponse<RoleResponse> mappingRolePaginatedResponse(IEnumerable<Role> roles, int page, int totalPage, int totalCount)
    {
        PaginatedResponse<RoleResponse> rolePaginatedResponse = new PaginatedResponse<RoleResponse>()
        {
            Message = "success",
            Data = _mapper.Map<IEnumerable<RoleResponse>>(roles),
            Page = page,
            TotalPage = totalPage,
            TotalCount = totalCount
        };

        return rolePaginatedResponse;
    }

    private async Task<Role> getRole(Guid id)
    {
        Role role = await _roleRepo.GetRole(id) ?? throw new KeyNotFoundException("Role Not Found");
        return role;
    }

    private async Task<Role> getFullRoleById(Guid id)
    {
        Role role = await _roleRepo.GetFullRole(id) ?? throw new KeyNotFoundException("Role Not Found");
        return role;
    }

}