using CleanArch.eShop.Domain.Common;

namespace CleanArch.eShop.Domain.Entities;

public class ProductCategory : BaseAuditableEntity
{
    public string? Name { get; set; }

    public string? Description { get; set; }

    public IList<Product> Products { get; private set; } = new List<Product>();
}
