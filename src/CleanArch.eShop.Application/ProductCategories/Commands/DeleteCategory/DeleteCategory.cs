using Ardalis.GuardClauses;
using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Events;
using MediatR;

namespace CleanArch.eShop.Application.ProductCategories.Commands.DeleteCategory
{
    public record DeleteCategoryCommand(int Id) : IRequest;

    public class DeleteCategoryCommandHandler(IApplicationDbContext context) : IRequestHandler<DeleteCategoryCommand>
    {
        public async Task Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await context.ProductCategories.FindAsync([request.Id], cancellationToken);

            Guard.Against.NotFound(request.Id, entity);

            context.ProductCategories.Remove(entity);

            entity.AddDomainEvent(new ProductCategoryDeletedEvent(entity));

            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
