using CleanArch.eShop.Domain.Common;

namespace CleanArch.eShop.Domain.Entities;

public class Discount : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public decimal DiscountPercent { get; set; }
    public bool Active { get; set; }
    
    public Product Product { get; set; }
}