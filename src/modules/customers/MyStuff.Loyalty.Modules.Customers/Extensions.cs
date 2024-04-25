using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using MyStuff.Loyalty.Common.Abstractions;

namespace MyStuff.Loyalty.Modules.Customers;

public static class Extensions
{
    public static void AddCustomersModule(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddEndpointDefinitions(typeof(Extensions));

        string connectionString = config.GetConnectionString("CustomerDatabase") ?? string.Empty;
        services.AddDbContext<CustomersDbContext>(options =>
             options.UseInMemoryDatabase(connectionString));
    }
}
