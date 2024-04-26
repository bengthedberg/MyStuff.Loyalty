using Microsoft.Extensions.DependencyInjection;

using MyStuff.Loyalty.Common.Abstractions;

namespace MyStuff.Loyalty.Common.Infrastructure;
public static class Extensions
{
    public static void AddSharedInfrastructure(this IServiceCollection services)
    {
        // Use abstraction of time, to easy unit testing.
        // See https://github.com/dotnet/runtime/blob/main/src/libraries/Common/src/System/TimeProvider.cs
        // https://blog.nimblepros.com/blogs/finally-an-abstraction-for-time-in-net/
        services.AddSingleton<TimeProvider>(TimeProvider.System);

        // Cross cutting endpoints, any minimal api ednpoints that are defined in this assembly.
        services.AddEndpointDefinitions(typeof(Extensions));
    }
}
