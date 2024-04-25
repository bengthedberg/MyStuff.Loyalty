using Microsoft.EntityFrameworkCore;

using MyStuff.Loyalty.Modules.Customers.Model;

namespace MyStuff.Loyalty.Modules.Customers.Services;

public class CustomersService : ICustomersService
{
    private readonly CustomersDbContext _ctx;

    public CustomersService(CustomersDbContext ctx)
    {
        _ctx = ctx;
    }

    public async Task<Customer?> Add(Customer customer)
    {
        _ctx.Customers.Add(customer);
        var saved = await _ctx.SaveChangesAsync();
        if (saved == 0)
        {
            return null;
        }
        else
        {
            return customer;
        }
    }


    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _ctx.Customers.ToListAsync();
    }

    public async Task<Customer?> GetById(int id)
    {
        return await _ctx.Customers.FirstOrDefaultAsync(x => x.Id == id);
    }
}
