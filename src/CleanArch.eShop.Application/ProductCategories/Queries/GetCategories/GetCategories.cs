using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.eShop.Application.ProductCategories.Queries.GetCategories;

public record GetCategoriesQuery : IRequest<List<ProductCategoryVm>>;

public class GetCategoriesQueryHandler(IDistributedCacheService cacheService, IApplicationDbContext context) : IRequestHandler<GetCategoriesQuery, List<ProductCategoryVm>>
{
    public async Task<List<ProductCategoryVm>> Handle(GetCategoriesQuery request, CancellationToken cancellationToken)
    {
        var cachedItems = await cacheService.GetFromCacheAsync<List<ProductCategoryVm>>(CacheKeys.ProductCategories);
        if(cachedItems is not null)
            return cachedItems;

        var items = await context.ProductCategories.AsNoTracking()
            .Select(c => new ProductCategoryVm() { Id = c.Id, Name = c.Name, Description = c.Description })
            .ToListAsync(cancellationToken);
        await cacheService.SetCacheAsync(CacheKeys.ProductCategories, items, new Microsoft.Extensions.Caching.Distributed.DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromDays(1)});

        return items;
    }
}