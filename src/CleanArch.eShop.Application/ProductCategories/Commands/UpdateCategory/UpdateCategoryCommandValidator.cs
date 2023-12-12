using FluentValidation;

namespace CleanArch.eShop.Application.ProductCategories.Commands.UpdateCategory
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();

            RuleFor(c => c.Name)
                .MaximumLength(255)
                .NotEmpty();

            RuleFor(c => c.Description)
                .MaximumLength(500);
        }
    }
}
