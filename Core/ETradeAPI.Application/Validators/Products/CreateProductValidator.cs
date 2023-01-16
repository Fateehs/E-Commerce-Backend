using ETradeAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETradeAPI.Application.Validators.Products
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Please fill the product name.")
                .MaximumLength(150).MinimumLength(1).WithMessage("The name of the product can be between 1 and 150 characters.");

            RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Please fill the stock amount")
                .Must(s => s >= 0).WithMessage("The stock amount of the product can be minimum 0.");
        }
    }
}
