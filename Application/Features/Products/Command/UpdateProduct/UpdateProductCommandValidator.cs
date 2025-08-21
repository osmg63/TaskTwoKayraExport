
using FluentValidation;

namespace Application.Features.Products.Command.UpdateProduct
{
    public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommandRequest>
    {
        public UpdateProductCommandValidator()
        {
            RuleFor(x => x.Name)
                    .NotEmpty();

            RuleFor(x => x.Description)
                    .NotEmpty();

            RuleFor(x => x.Price)
                    .GreaterThan(0);

            RuleFor(x => x.Discount)
                    .GreaterThanOrEqualTo(0);

            RuleFor(x => x.Stock)
                    .GreaterThanOrEqualTo(0);
        }
    }
}
