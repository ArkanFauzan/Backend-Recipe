using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;

namespace RecipeApi.Seeders;

public static class PermissionSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>().HasData(
            new Permission {
                Id = Guid.Parse("56b71bb1-3b72-4086-ac48-e326ddd55ce0"),
                Name = "Recipe Management",
                ControllerName = "recipe",
                Order = 1,
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            }
        );
    }
}