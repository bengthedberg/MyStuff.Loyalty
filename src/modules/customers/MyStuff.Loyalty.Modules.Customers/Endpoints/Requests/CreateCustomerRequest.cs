namespace MyStuff.Loyalty.Modules.Customers.Endpoints.Requests;

public record CreateCustomerRequest
{
    required public string Name { get; init;}
}
