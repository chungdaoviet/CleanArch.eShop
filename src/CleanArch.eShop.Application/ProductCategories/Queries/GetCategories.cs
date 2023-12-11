using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.eShop.Application.ProductCategories.Queries;

public record GetCategoriesQuery : IRequest<List<ProductCategory>>;

public class GetCategoriesQueryHandler : IRequestHandler<GetCategoriesQuery, List<ProductCategory>>
{
    private readonly IApplicationDbContext _context;

    public GetCategoriesQueryHandler(IApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<ProductCategory>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var items = await _context.ProductCategories.AsNoTracking().ToListAsync(cancellationToken);

        return items;
    }
}