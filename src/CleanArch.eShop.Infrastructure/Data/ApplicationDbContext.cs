using System.Reflection;
using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Entities;
using CleanArch.eShop.Infrastructure.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArch.eShop.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){}

    public DbSet<ProductCategory> ProductCategories => Set<ProductCategory>();

    public DbSet<ProductInventory> ProductInventories => Set<ProductInventory>();

    public DbSet<Discount> Discounts => Set<Discount>();

    public DbSet<Product> Products => Set<Product>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        
        base.OnModelCreating(builder);
    }
}