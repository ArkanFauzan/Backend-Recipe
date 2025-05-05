using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;
using RecipeApi.Helpers;

namespace RecipeApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.AddInterceptors(new AutofillDateTimeInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyGlobalFilters<ISoftDelete>(x => x.DeletedAt == null);
    }
}
