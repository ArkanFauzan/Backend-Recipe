using RecipeApi.BaseModule.Models.Base;
using RecipeApi.Entities;
using RecipeApi.AccountModule.Models.Role;

namespace RecipeApi.AccountModule.Interfaces.Repositories;

public interface IRoleRepo
{
    Task<List<Role>> GetAllRoles(ListFilter filter);
    Task<(List<Role>, int, int)> GetPaginatedRoles(RoleFilter roleFilter, int pageIndex, int pageSize);
    Task<Role?> GetRole(Guid id);
    Task<Role?> GetFullRole(Guid id);
    Task<bool> CheckRoleIdExist(Guid id);
    Task CreateRole(Role role);
    Task UpdateRole(Role role);
    Task DeleteRole(Role role);
}