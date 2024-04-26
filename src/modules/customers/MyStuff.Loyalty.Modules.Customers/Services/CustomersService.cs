using Microsoft.EntityFrameworkCore;

using MyStuff.Loyalty.Modules.Customers.Model;

namespace MyStuff.Loyalty.Modules.Customers.Services;

public class CustomersService : ICustomersService
{
    private readonly CustomersDbContext _ctx;
    private readonly TimeProvider _timeProvider;

    public CustomersService(CustomersDbContext ctx, TimeProvider timeProvider)
    {
        _ctx = ctx;
        _timeProvider = timeProvider;
    }

    public async Task<Customer?> AddCustomerAsync(Customer newCustomer)
    {
        newCustomer.DateCreated = _timeProvider.GetUtcNow();
        _ctx.Customers.Add(newCustomer);
        var saved = await _ctx.SaveChangesAsync();
        if (saved == 0)
        {
            return null;
        }
        else
        {
            return newCustomer;
        }
    }

    public async Task DeleteCustomer(int id)
    {
        var customer = await _ctx.Customers.FirstOrDefaultAsync(p => p.Id == id);
        if (customer == null)
        {
            return;
        }
        _ctx.Customers.Remove(customer);
        await _ctx.SaveChangesAsync();
    }

    public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
    {
        return await _ctx.Customers.ToListAsync();
    }

    public async Task<Customer?> GetCustomerByIdAsync(int id)
    {
        return await _ctx.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task UpdateCustomer(int id, string name)
    {
        var customer = await _ctx.Customers.FirstOrDefaultAsync(p => p.Id == id);
        if (customer == null)
        {
            return;
        }
        customer.Name = name;
        customer.LastModified = _timeProvider.GetUtcNow();
        await _ctx.SaveChangesAsync();
    }
}
