using Microsoft.Extensions.DependencyInjection;

using MyStuff.Loyalty.Common.Abstractions;

namespace MyStuff.Loyalty.Modules.Customers;

public static class Extensions
{
    public static void AddCustomersModule(this IServiceCollection services)
    {
        services.AddEndpointDefinitions(typeof(Extensions));
    }
}
