using CleanArch.eShop.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.eShop.Application.ProductCategories.EventHandlers;

public class ProductCategoryCreatedEventHandler(ILogger<ProductCategoryCreatedEventHandler> logger) : INotificationHandler<ProductCategoryCreatedEvent>
{
    public Task Handle(ProductCategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}