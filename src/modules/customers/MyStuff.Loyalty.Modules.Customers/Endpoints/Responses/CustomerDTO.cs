using MyStuff.Loyalty.Modules.Customers.Model;

namespace MyStuff.Loyalty.Modules.Customers.Endpoints.Responses;

public record CustomerDTO 
{
    required public int Id {get; init; }
    required public string Name { get; init; }
    required public DateTimeOffset Updated { get; init; }

    public static CustomerDTO MapFrom(Customer customer) => 
        new CustomerDTO { 
            Id = customer.Id, 
            Name = customer.Name, 
            Updated = customer.LastModified ?? customer.DateCreated
        };

}