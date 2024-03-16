using FluentValidation;

namespace Test.Application.Product.Queries;

public class ProductDetailsQueryValidator : AbstractValidator<ProductDetailsQuery>
{
    public ProductDetailsQueryValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .Matches(@"^({){0,1}[0-9a-fA-F]{8}-([0-9a-fA-F]{4}-){3}[0-9a-fA-F]{12}(}){0,1}$")
            .WithMessage("Invalid GUID format.");
    }
    
}