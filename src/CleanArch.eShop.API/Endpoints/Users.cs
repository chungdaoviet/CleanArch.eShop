using CleanArch.eShop.API.Infrastructure;
using CleanArch.eShop.Infrastructure.Identity;

namespace CleanArch.eShop.API.Endpoints;

public class Users : EndpointGroupBase
{
    public override void Map(WebApplication app)
    {
        app.MapGroup(this)
            .MapIdentityApi<ApplicationUser>().WithOpenApi();
    }
}