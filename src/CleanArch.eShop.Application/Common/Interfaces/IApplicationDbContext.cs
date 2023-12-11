using CleanArch.eShop.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.eShop.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<ProductCategory> ProductCategories { get; }
    
    DbSet<ProductInventory> ProductInventories { get; }
    
    DbSet<Discount> Discounts { get; }
    
    DbSet<Product> Products { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}