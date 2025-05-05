using Microsoft.EntityFrameworkCore;
using RecipeApi.Entities;
using RecipeApi.Helpers;

namespace RecipeApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Recipe> Recipes { get; set; }
    public DbSet<Step> Steps { get; set; }
    public DbSet<DataType> DataTypes { get; set; }
    public DbSet<StepParameterTemplate> StepParameterTemplates { get; set; }
    public DbSet<StepParameter> StepParameters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.AddInterceptors(new AutofillDateTimeInterceptor());
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Step>()
            .HasOne(s => s.Parent)
            .WithMany(s => s.Children)
            .HasForeignKey(s => s.ParentId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<DataType>()
            .Property(d => d.ParseType)
            .HasConversion<string>(); // enum string untuk PostgreSQL
        
        // Apply global filter
        modelBuilder.ApplyGlobalFilters<ISoftDelete>(x => x.DeletedAt == null);
    }
}
