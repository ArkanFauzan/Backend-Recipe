using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;

namespace RecipeApi.Seeders;

public static class PermissionMethodSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PermissionMethod>().HasData(
            new PermissionMethod { Id = Guid.Parse("12bf6fa5-4aa0-4721-866a-f595c2d889ef"), Method = "view", PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new PermissionMethod { Id = Guid.Parse("fd1c7b7a-7cce-4d65-a27e-5c3b701a3484"), Method = "create", PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new PermissionMethod { Id = Guid.Parse("3dbbfcf0-9b23-47cd-a4dc-c4cc0987291f"), Method = "update", PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new PermissionMethod { Id = Guid.Parse("7768fcd1-cebe-4a0f-8e62-2b8f5ce32e1e"), Method = "delete", PermissionId = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"), Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() }
        );
    }
}