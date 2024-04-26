namespace MyStuff.Loyalty.Modules.Customers.Endpoints.Requests;

public record UpdateCustomerRequest
{
    required public string Name { get; init;}
}
