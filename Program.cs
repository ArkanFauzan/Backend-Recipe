using RecipeApi.Data;
using Microsoft.EntityFrameworkCore;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Services;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Repositories;
using RecipeApi.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// PostgreSQL connection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "AllowAll", builder =>
    {
        builder
            .SetIsOriginAllowed(origin => true)
            .AllowAnyMethod()
            .AllowAnyHeader()
            .AllowCredentials();
    });
});

// Repositories
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>();
builder.Services.AddScoped<IStepRepo, StepRepo>();
builder.Services.AddScoped<IDataTypeRepo, DataTypeRepo>();
builder.Services.AddScoped<IStepParameterTemplateRepo, StepParameterTemplateRepo>();
builder.Services.AddScoped<IStepParameterRepo, StepParameterRepo>();

// Services
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IDataTypeService, DataTypeService>();
builder.Services.AddScoped<IStepParameterTemplateService, StepParameterTemplateService>();
builder.Services.AddScoped<IStepParameterService, StepParameterService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("AllowAll");

app.Run();
