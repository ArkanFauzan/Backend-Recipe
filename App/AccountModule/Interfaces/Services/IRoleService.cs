using RecipeApi.BaseModule.Models.Base;
using RecipeApi.AccountModule.Models.Role;

namespace RecipeApi.AccountModule.Interfaces.Services;

public interface IRoleService
{
    Task<List<SelectDataResponse>> GetListRole(ListFilter filter);
    Task<PaginatedResponse<RoleResponse>> GetPaginatedRole(RoleFilter filter);
    Task<RoleResponseSingle> GetRoleById(Guid id);
    Task<RoleResponse> CreateRole(CreateRoleRequest model);
    Task<RoleResponse> UpdateRole(Guid id, UpdateRoleRequest model);
    Task DeleteRole(Guid id);

}