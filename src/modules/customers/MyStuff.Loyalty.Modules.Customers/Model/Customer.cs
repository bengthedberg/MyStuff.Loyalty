namespace MyStuff.Loyalty.Modules.Customers.Model;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset DateCreated { get; set; } = DateTime.UtcNow;
    public DateTimeOffset? LastModified  { get; set; }

}
