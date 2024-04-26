namespace MyStuff.Loyalty.Modules.Customers.Contracts.DTOs;

public record CreateCustomerRequestDTO
{
    required public string Name { get; init;}
}
