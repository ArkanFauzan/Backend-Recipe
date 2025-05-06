using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace RecipeApi.Helpers;

public class CustomAuthorizationPolicyProvider : DefaultAuthorizationPolicyProvider
{
    private readonly AuthorizationOptions _options;

    public CustomAuthorizationPolicyProvider(IOptions<AuthorizationOptions> options)
        : base(options)
    {
        _options = options.Value;
    }

    public override Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
    {
        var policy = new AuthorizationPolicyBuilder()
            .AddRequirements(new PermissionRequirement(policyName))
            .Build();

        _options.AddPolicy(policyName, policy);
        return Task.FromResult<AuthorizationPolicy?>(policy);
    }
}