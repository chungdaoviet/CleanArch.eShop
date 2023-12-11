using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Entities;
using CleanArch.eShop.Domain.Events;
using MediatR;

namespace CleanArch.eShop.Application.ProductCategories.Commands.CreateProductCategory;

public record CreateProductCategoryCommand : IRequest<int>
{
    public string? Name { get; init; }
    public string? Description { get; init; }
}

public class CreateProductCategoryCommandHandler : IRequestHandler<CreateProductCategoryCommand, int>
{
    private readonly IApplicationDbContext _context;

    public CreateProductCategoryCommandHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<int> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = new ProductCategory()
        {
            Name = request.Name,
            Description = request.Description,
        };
        
        entity.AddDomainEvent(new ProductCategoryCreatedEvent(entity));
        
        _context.ProductCategories.Add(entity);

        await _context.SaveChangesAsync(cancellationToken);

        return entity.Id;
    }
}