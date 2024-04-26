using MyStuff.Loyalty.Modules.Customers.Model;

namespace MyStuff.Loyalty.Modules.Customers.Services;

public interface ICustomersService
{
    Task<IEnumerable<Customer>> GetAllCustomersAsync();
    Task<Customer?> GetCustomerByIdAsync(int id);
    Task<Customer?> AddCustomerAsync(Customer newCustomer);
    Task DeleteCustomer(int id);
    Task UpdateCustomer(int id, string name);
}