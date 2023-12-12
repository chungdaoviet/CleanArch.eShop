using FluentValidation;

namespace CleanArch.eShop.Application.ProductCategories.Commands.CreateCategory;

public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(r => r.Name)
            .MaximumLength(255)
            .NotEmpty();

        RuleFor(r => r.Description)
            .MaximumLength(500);
    }
}