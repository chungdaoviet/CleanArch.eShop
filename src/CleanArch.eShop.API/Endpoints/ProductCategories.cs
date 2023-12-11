using CleanArch.eShop.API.Infrastructure;
using CleanArch.eShop.Application.ProductCategories.Commands.CreateProductCategory;
using CleanArch.eShop.Application.ProductCategories.Queries;
using CleanArch.eShop.Domain.Entities;
using MediatR;

namespace CleanArch.eShop.API.Endpoints;

public class ProductCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCategories)
            .MapPost(CreateCategory);
    }

    private async Task<List<ProductCategory>> GetCategories(ISender sender)
    {
        return await sender.Send(new GetCategoriesQuery());
    }

    private async Task<int> CreateCategory(ISender sender, CreateProductCategoryCommand command)
    {
        return await sender.Send(command);
    }
}