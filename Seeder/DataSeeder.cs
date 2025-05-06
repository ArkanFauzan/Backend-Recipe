using Microsoft.EntityFrameworkCore;

namespace RecipeApi.Seeders;

public static class DataSeeder
{
    public static void SeedAll(ModelBuilder modelBuilder)
    {
        RoleSeeder.Seed(modelBuilder);
        PermissionSeeder.Seed(modelBuilder);
        PermissionMethodSeeder.Seed(modelBuilder);
        RolePermissionMethodSeeder.Seed(modelBuilder);
        AccountSeeder.Seed(modelBuilder);
    }
}