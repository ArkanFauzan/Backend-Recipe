using RecipeApi.Data;
using Microsoft.EntityFrameworkCore;
using RecipeApi.RecipeModule.Interfaces.Services;
using RecipeApi.RecipeModule.Services;
using RecipeApi.RecipeModule.Interfaces.Repositories;
using RecipeApi.RecipeModule.Repositories;
using RecipeApi.Middlewares;
using Microsoft.AspNetCore.Authorization;
using RecipeApi.Helpers;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using RecipeApi.AccountModule.Interfaces.Repositories;
using RecipeApi.AccountModule.Repositories;
using RecipeApi.AccountModule.Interfaces.Services;
using RecipeApi.AccountModule.Services;

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

// Auth & Authorization
var jwtSettingsSection = builder.Configuration.GetSection("JwtSettings");
builder.Services.Configure<JwtSettings>(jwtSettingsSection);
var jwtSettings = jwtSettingsSection.Get<JwtSettings>();

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });

builder.Services.AddScoped<IAuthorizationHandler, PermissionAuthorizationHandler>();
builder.Services.AddSingleton<IAuthorizationPolicyProvider, CustomAuthorizationPolicyProvider>();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new() { Title = "Recipe API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Masukkan 'Bearer {token}'"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});


// Repositories
builder.Services.AddScoped<IRecipeRepo, RecipeRepo>();
builder.Services.AddScoped<IStepRepo, StepRepo>();
builder.Services.AddScoped<IDataTypeRepo, DataTypeRepo>();
builder.Services.AddScoped<IStepParameterTemplateRepo, StepParameterTemplateRepo>();
builder.Services.AddScoped<IStepParameterRepo, StepParameterRepo>();
builder.Services.AddScoped<IRoleRepo, RoleRepo>();
builder.Services.AddScoped<IAccountRepo, AccountRepo>();

// Services
builder.Services.AddScoped<IRecipeService, RecipeService>();
builder.Services.AddScoped<IStepService, StepService>();
builder.Services.AddScoped<IDataTypeService, DataTypeService>();
builder.Services.AddScoped<IStepParameterTemplateService, StepParameterTemplateService>();
builder.Services.AddScoped<IStepParameterService, StepParameterService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAccountService, AccountService>();

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.UseCors("AllowAll");

app.Run();
