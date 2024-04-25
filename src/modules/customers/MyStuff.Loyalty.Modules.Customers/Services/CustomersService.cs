using MyStuff.Loyalty.Modules.Customers.Model;

namespace MyStuff.Loyalty.Modules.Customers.Services;

public class CustomersService : ICustomersService
{
    public IEnumerable<Customer> GetAll()
    {
        return new List<Customer>();
    }
}
