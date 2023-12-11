using CleanArch.eShop.Domain.Events;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArch.eShop.Application.ProductCategories.EventHandlers;

public class ProductCategoryCreatedEventHandler : INotificationHandler<ProductCategoryCreatedEvent>
{
    private readonly ILogger<ProductCategoryCreatedEventHandler> _logger;

    public ProductCategoryCreatedEventHandler(ILogger<ProductCategoryCreatedEventHandler> logger)
    {
        _logger = logger;
    }
    
    public Task Handle(ProductCategoryCreatedEvent notification, CancellationToken cancellationToken)
    {
        _logger.LogInformation("CleanArchitecture Domain Event: {DomainEvent}", notification.GetType().Name);

        return Task.CompletedTask;
    }
}