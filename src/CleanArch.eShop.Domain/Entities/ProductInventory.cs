using CleanArch.eShop.Domain.Common;

namespace CleanArch.eShop.Domain.Entities;

public class ProductInventory : BaseAuditableEntity
{
    public int Quantity { get; set; }
}