using CleanArch.eShop.API.Endpoints;
using CleanArch.eShop.API.Infrastructure;
using CleanArch.eShop.API.Services;
using CleanArch.eShop.Application;
using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Infrastructure;
using CleanArch.eShop.Infrastructure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUser, CurrentUser>();

builder.Services.AddExceptionHandler<CustomExceptionHandler>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    
} else
{
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseExceptionHandler(options => {});

app.MapEndpoints();

app.Run();
