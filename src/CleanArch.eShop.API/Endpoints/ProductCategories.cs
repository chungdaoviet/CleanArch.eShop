using CleanArch.eShop.API.Infrastructure;
using CleanArch.eShop.Application.ProductCategories.Commands.CreateCategory;
using CleanArch.eShop.Application.ProductCategories.Commands.DeleteCategory;
using CleanArch.eShop.Application.ProductCategories.Commands.UpdateCategory;
using CleanArch.eShop.Application.ProductCategories.Queries.GetCategories;
using MediatR;

namespace CleanArch.eShop.API.Endpoints;

public class ProductCategories : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapGet(GetCategories)
            .MapPost(CreateCategory)
            .MapPut(UpdateCategory, "{id}")
            .MapDelete(DeleteCategory, "{id}");
    }

    private async Task<List<ProductCategoryVm>> GetCategories(ISender sender)
    {
        return await sender.Send(new GetCategoriesQuery());
    }

    private async Task<int> CreateCategory(ISender sender, CreateCategoryCommand command)
    {
        return await sender.Send(command);
    }

    private async Task<IResult> UpdateCategory(ISender sender, int id, UpdateCategoryCommand command)
    {
        if(id != command.Id)
            return Results.BadRequest();
        await sender.Send(command);

        return Results.NoContent();
    }

    private async Task<IResult> DeleteCategory(ISender sender, int id)
    {
        await sender.Send(new DeleteCategoryCommand(id));

        return Results.NoContent();
    }
}