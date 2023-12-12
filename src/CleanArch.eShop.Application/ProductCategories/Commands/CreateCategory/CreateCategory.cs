using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Entities;
using CleanArch.eShop.Domain.Events;
using MediatR;

namespace CleanArch.eShop.Application.ProductCategories.Commands.CreateCategory;

public record CreateCategoryCommand : IRequest<int>
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public class CreateCategoryCommandHandler(IApplicationDbContext context) : IRequestHandler<CreateCategoryCommand, int>
{
    public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductCategory()
        {
            Name = request.Name,
            Description = request.Description,
        };
        
        entity.AddDomainEvent(new ProductCategoryCreatedEvent(entity));
        
        context.ProductCategories.Add(entity);

        await context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}