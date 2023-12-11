using CleanArch.eShop.Domain.Common;
using CleanArch.eShop.Domain.Entities;

namespace CleanArch.eShop.Domain.Events;

public class ProductCategoryCreatedEvent : BaseEvent
{
    public ProductCategoryCreatedEvent(ProductCategory item)
    {
        Item = item;
    }
    public ProductCategory Item { get; }
}