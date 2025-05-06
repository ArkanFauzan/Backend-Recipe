using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;

namespace RecipeApi.Seeders;

public static class RoleSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>().HasData(
            new Role { Id = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"), RoleName = "Super Admin", Description = "Super admin access", Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new Role { Id = Guid.Parse("21b67a56-7c4a-4b13-b14a-1eb9c643d09c"), RoleName = "Admin", Description = "Admin access", Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new Role { Id = Guid.Parse("b4bd8623-5fb5-42d7-8b6f-6ff58813a3b0"), RoleName = "User", Description = "Regular user", Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() }
        );
    }
}