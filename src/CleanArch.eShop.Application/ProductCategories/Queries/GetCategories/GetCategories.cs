using CleanArch.eShop.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.eShop.Application.ProductCategories.Queries.GetCategories;

public record GetCategoriesQuery : IRequest<List<ProductCategoryVm>>;

public class GetCategoriesQueryHandler(IApplicationDbContext context) : IRequestHandler<GetCategoriesQuery, List<ProductCategoryVm>>
{
    public async Task<List<ProductCategoryVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var items = await context.ProductCategories.AsNoTracking()
            .Select(c => new ProductCategoryVm() { Id = c.Id, Name = c.Name, Description = c.Description })
            .ToListAsync(cancellationToken);

        return items;
    }
}