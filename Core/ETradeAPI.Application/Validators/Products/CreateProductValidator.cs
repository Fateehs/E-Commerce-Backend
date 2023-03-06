using ETradeAPI.Application.ViewModels.Products;
using FluentValidation;

namespace ETradeAPI.Application.Validators.Products
{
    public class CreateProductValidator 
    {
    //    public CreateProductValidator()
    //    {
    //        RuleFor(p => p.Name).NotEmpty().NotNull().WithMessage("Please fill the product name.")
    //            .MaximumLength(150).MinimumLength(2).WithMessage("The name of the product can be between 1 and 150 characters.");

    //        RuleFor(p => p.Price).NotEmpty().NotNull().WithMessage("Price cannot be blank.")
    //            .Must(p => p >= 0).WithMessage("The price of the procut can be minumum 0.");

    //        RuleFor(p => p.Stock).NotEmpty().NotNull().WithMessage("Please fill the stock amount")
    //            .Must(s => s >= 0).WithMessage("The stock amount of the product can be minimum 0.");
    //    }
    }
}
