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
            },
            new Permission { Id = Guid.Parse("01ce2ff6-31d0-4b70-a3f2-2d37bf897a5b"), Name = "Data Type Management", ControllerName = "data-type", Order = 2, Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new Permission { Id = Guid.Parse("40b29d47-acff-47f5-9575-58e2fd403342"), Name = "Step Parameter Template Management", ControllerName = "step-parameter-template", Order = 3, Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new Permission { Id = Guid.Parse("8a000102-7cdd-4793-b489-a19f747fc356"), Name = "Step Parameter Management", ControllerName = "step-parameter", Order = 4, Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new Permission { Id = Guid.Parse("2341db7d-68c5-4803-bdd9-3ac658adc3cf"), Name = "Step Management", ControllerName = "step", Order = 5, Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() },
            new Permission { Id = Guid.Parse("8e83d27f-f32a-4ce3-a649-5dbdd0f65492"), Name = "Account Management", ControllerName = "account", Order = 6, Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime() }
        );
    }
}