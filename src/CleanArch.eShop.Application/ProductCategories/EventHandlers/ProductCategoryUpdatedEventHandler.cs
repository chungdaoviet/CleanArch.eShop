using CleanArch.eShop.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.eShop.Application.ProductCategories.EventHandlers;

public class ProductCategoryDeletedEventHandler(ILogger<ProductCategoryDeletedEventHandler> logger) : INotificationHandler<ProductCategoryDeletedEvent>
{
    public Task Handle(ProductCategoryDeletedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}