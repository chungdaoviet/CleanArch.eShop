using FluentValidation;

namespace CleanArch.eShop.Application.ProductCategories.Commands.CreateProductCategory;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(r => r.Name)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(r => r.Description)
            .MaximumLength(500);
    }
}