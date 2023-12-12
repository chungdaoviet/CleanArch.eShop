using Ardalis.GuardClauses;
using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Events;
using MediatR;

namespace CleanArch.eShop.Application.ProductCategories.Commands.UpdateCategory
{
    public record UpdateCategoryCommand : IRequest
    {
        public int Id { get; init; }
        public string? Name { get; init; }

        public string? Description { get; init; }
    }

    public class UpdateCategoryCommandHandler(IApplicationDbContext context) : IRequestHandler<UpdateCategoryCommand>
    {
        public async Task Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.ProductCategories.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            entity.Name = request.Name;
            entity.Description = request.Description;

            entity.AddDomainEvent(new ProductCategoryUpdatedEvent(entity));

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
