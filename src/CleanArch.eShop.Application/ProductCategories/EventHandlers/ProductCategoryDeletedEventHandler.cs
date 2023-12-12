using CleanArch.eShop.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.eShop.Application.ProductCategories.EventHandlers;

public class ProductCategoryUpdatedEventHandler(ILogger<ProductCategoryUpdatedEventHandler> logger) : INotificationHandler<ProductCategoryUpdatedEvent>
{
    public Task Handle(ProductCategoryUpdatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}