using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore.Query;
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
        app.MapGet("customers/{id}", GetCustomerById).WithName("GetById");
        app.MapPost("customers", AddCustomer);
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
    }

    internal async Task<IEnumerable<Customer>> GetAllCustomers(ICustomersService customersService)
    {
        return await customersService.GetAll();
    }

    internal async Task<IResult> GetCustomerById(ICustomersService customersService, int id)
    {
        var customer = await customersService.GetById(id);
        if (customer is null)
        {
            return Results.NotFound(id);
        }
        return Results.Ok(customer);
    }

    internal async Task<IResult> AddCustomer(ICustomersService customersService, Customer customer)
    {
        var newCustomer = await customersService.Add(customer);
        if (newCustomer is null)
        {
            return Results.BadRequest(customer);
        }
        return Results.CreatedAtRoute("GetById", new { id = newCustomer.Id}, newCustomer);
    }
}
