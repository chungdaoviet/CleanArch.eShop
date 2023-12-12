using CleanArch.eShop.Domain.Common;
using CleanArch.eShop.Domain.Entities;

namespace CleanArch.eShop.Domain.Events;

public class ProductCategoryUpdatedEvent : BaseEvent
{
    public ProductCategoryUpdatedEvent(ProductCategory item)
    {
        Item = item;
    }
    public ProductCategory Item { get; }
}