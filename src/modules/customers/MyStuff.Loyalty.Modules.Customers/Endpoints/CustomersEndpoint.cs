using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

using MyStuff.Loyalty.Common.Abstractions;
using MyStuff.Loyalty.Modules.Customers.Contracts.DTOs;
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
        app.MapPut("customers/{id}", UpdateCustomer);
        app.MapDelete("customers/{id}", DeleteCustomerById);
    }

    public void DefineServices(IServiceCollection services)
    {
        services.AddScoped<ICustomersService, CustomersService>();
    }

    internal async Task<IResult> GetAllCustomers(ICustomersService customersService)
    {
        var customers = await customersService.GetAllCustomersAsync();
        var response = customers.Select(c => CustomerDTO.MapFrom(c));
        return TypedResults.Ok(response);
    }

    internal async Task<IResult> GetCustomerById(ICustomersService customersService, int id)
    {
        var customer = await customersService.GetCustomerByIdAsync(id);
        var response = CustomerDTO.MapFrom(customer);
        return customer is not null ? Results.Ok(response) : Results.NotFound();
    }

    internal async Task<IResult> AddCustomer(ICustomersService customersService, CreateCustomerRequestDTO request)
    {
        var newCustomer = await customersService.AddCustomerAsync(new Customer { Name = request.Name });
        var response = CustomerDTO.MapFrom(newCustomer);
        return TypedResults.CreatedAtRoute<CustomerDTO>(response, "GetCustomerById", new { id = response.Id});
    }

    internal async Task<IResult> UpdateCustomer(ICustomersService customersService, int id, UpdateCustomerRequestDTO request)
    {
        await customersService.UpdateCustomer(id, request.Name);
        return Results.NoContent();
    }

    internal async static Task<IResult> DeleteCustomerById(ICustomersService customersService, int id)
    {
        await customersService.DeleteCustomer(id);
        return TypedResults.NoContent();
    }
}
