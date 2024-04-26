using FluentValidation;

namespace MyStuff.Loyalty.Modules.Customers.Endpoints.Requests;

public class CreateCustomerRequestValidator : AbstractValidator<CreateCustomerRequest>
{
    public CreateCustomerRequestValidator()
    {
        RuleFor(post => post.Name)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("Request must contain a name")
            .NotNull().WithMessage("Name is required");
    }
}
