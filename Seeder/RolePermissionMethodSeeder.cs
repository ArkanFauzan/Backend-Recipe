using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;

namespace RecipeApi.Seeders;

public static class RolePermissionMethodSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<RolePermissionMethod>().HasData(
            new RolePermissionMethod { Id = Guid.Parse("fe193127-feba-4007-b760-912245e4018c"), RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), PermissionMethodId = Guid.Parse("12bf6fa5-4aa0-4721-866a-f595c2d889ef"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new RolePermissionMethod { Id = Guid.Parse("beb90ff7-da87-4879-aed6-31d9a5e448d4"), RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), PermissionMethodId = Guid.Parse("fd1c7b7a-7cce-4d65-a27e-5c3b701a3484"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new RolePermissionMethod { Id = Guid.Parse("ca1fd896-d93a-4ea3-aeef-c367ef3d1864"), RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), PermissionMethodId = Guid.Parse("3dbbfcf0-9b23-47cd-a4dc-c4cc0987291f"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new RolePermissionMethod { Id = Guid.Parse("adb0d599-4f9c-4c55-8d92-526590157bb4"), RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), PermissionMethodId = Guid.Parse("7768fcd1-cebe-4a0f-8e62-2b8f5ce32e1e"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() }
        );
    }
}