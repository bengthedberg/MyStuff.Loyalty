using MyStuff.Loyalty.Common.Abstractions;
using MyStuff.Loyalty.Common.Infrastructure;
using MyStuff.Loyalty.Modules.Customers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCustomersModule(builder.Configuration);
builder.Services.AddSharedInfrastructure();

var app = builder.Build();

app.UseMiddleware<ExceptionHandleMiddleware>();
app.UseEndPointDefinitions();

app.Run();
