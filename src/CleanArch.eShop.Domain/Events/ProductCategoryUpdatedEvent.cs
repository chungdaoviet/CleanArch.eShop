using CleanArch.eShop.Domain.Common;
using CleanArch.eShop.Domain.Entities;

namespace CleanArch.eShop.Domain.Events;

public class ProductCategoryDeletedEvent : BaseEvent
{
    public ProductCategoryDeletedEvent(ProductCategory item)
    {
        Item = item;
    }
    public ProductCategory Item { get; }
}