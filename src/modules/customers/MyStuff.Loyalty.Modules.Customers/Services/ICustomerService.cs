using MyStuff.Loyalty.Modules.Customers.Model;

namespace MyStuff.Loyalty.Modules.Customers.Services;

public interface ICustomersService
{
    Task<IEnumerable<Customer>> GetAll();

}