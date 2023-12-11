using CleanArch.eShop.Domain.Common;

namespace CleanArch.eShop.Domain.Entities;

public class Product : BaseAuditableEntity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Sku { get; set; }
    
    public int CategoryId { get; set; }
    public ProductCategory Category { get; set; }
    
    public int InventoryId { get; set; }
    public ProductInventory Inventory { get; set; }
    
    public decimal Price { get; set; }
    
    public int DiscountId { get; set; }
    public Discount Discount { get; set; }
}