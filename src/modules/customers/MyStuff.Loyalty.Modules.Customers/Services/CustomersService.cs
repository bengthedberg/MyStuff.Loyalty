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

    public async Task<IEnumerable<Customer>> GetAll()
    {
        return await _ctx.Customers.ToListAsync();
    }

}
