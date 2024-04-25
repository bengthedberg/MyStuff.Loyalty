using Microsoft.Extensions.DependencyInjection;

using MyStuff.Loyalty.Common.Abstractions;

namespace MyStuff.Loyalty.Common.Infrastructure;
public static class Extensions
{
    public static void AddSharedInfrastructure(this IServiceCollection services)
    {
        services.AddEndpointDefinitions(typeof(Extensions));
    }
}
