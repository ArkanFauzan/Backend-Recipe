using Microsoft.EntityFrameworkCore;
using AccountEntity = RecipeApi.Entities.Account;

namespace RecipeApi.Seeders;

public static class AccountSeeder
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AccountEntity>().HasData(
            new AccountEntity
            {
                Id = Guid.Parse("687efa72-305a-4fd6-a5df-2fc838ffa837"),
                Username = "superadmin",
                FullName = "Super Admin",
                Email = "super@admin.com",
                Password = "$2a$12$A2HSfL89FCvuX6uHixiVBuGrl2eKDvPwjDFxbX2yr12.0JDVVZoqi",
                RoleId = Guid.Parse("e287d2e0-9ca7-4a6e-aafe-08982ff2c5f8"),
                Created = DateTime.Parse("2025-05-06T01:13:46.418615").ToUniversalTime()
            }
        );
    }
}