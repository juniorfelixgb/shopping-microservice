using FluentValidation;

namespace Catalog.Application.Products.UpdateProduct;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(p => p.Id)
            .NotEmpty()
            .WithMessage("Id is required.");
        RuleFor(p => p.UpdateProduct.Name)
            .NotEmpty()
            .WithMessage("Name is required.");

        RuleFor(p => p.UpdateProduct.Category)
            .NotEmpty()
            .WithMessage("Category is required.");

        RuleFor(p => p.UpdateProduct.ImageFile)
            .NotEmpty()
            .WithMessage("Image is required.");

        RuleFor(p => p.UpdateProduct.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0");
    }
}
