using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using MyStuff.Loyalty.Common.Abstractions;
using MyStuff.Loyalty.Modules.Customers.Model;
using MyStuff.Loyalty.Modules.Customers.Services;

namespace MyStuff.Loyalty.Modules.Customers.Endpoints;

public class CustomersEndpoint : IEndpointDefinition
{
    public void DefineEndpoints(WebApplication app)
    {
        app.MapGet("customers", GetAllCustomers);
        app.MapGet("customers/{id}", GetCustomerById).WithName("GetCustomerById");
        app.MapPost("customers", AddCustomer);
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
    }

    internal async Task<IResult> GetAllCustomers(ICustomersService customersService)
    {
        var customers = await customersService.GetAllCustomersAsync();
        return TypedResults.Ok(customers);
    }

    internal async Task<IResult> GetCustomerById(ICustomersService customersService, int id)
    {
        var customer = await customersService.GetCustomerByIdAsync(id);
        if (customer is null)
        {
            return Results.NotFound(id);
        }
        return TypedResults.Ok(customer);
    }

    internal async Task<IResult> AddCustomer(ICustomersService customersService, Customer customer)
    {
        var newCustomer = await customersService.AddCustomerAsync(customer);
        if (newCustomer is null)
        {
            return TypedResults.BadRequest(customer);
        }
        return TypedResults.CreatedAtRoute<Customer>(newCustomer, "GetCustomerById", new { id = newCustomer.Id});
    }
}
