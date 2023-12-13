using Ardalis.GuardClauses;
using CleanArch.eShop.Application.Common.Interfaces;
using CleanArch.eShop.Domain.Constants;
using CleanArch.eShop.Infrastructure.Configurations;
using CleanArch.eShop.Infrastructure.Data;
using CleanArch.eShop.Infrastructure.Data.Interceptors;
using CleanArch.eShop.Infrastructure.Identity;
using CleanArch.eShop.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Quartz;

namespace CleanArch.eShop.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        Guard.Against.Null(connectionString, message: "Connection string 'DefaultConnection' not found.");

        services.AddScoped<ISaveChangesInterceptor, AuditableEntityInterceptor>();
        services.AddScoped<ISaveChangesInterceptor, DispatchDomainEventsInterceptor>();

        services.AddDbContext<ApplicationDbContext>((sp, options) =>
        {
            var interceptors = sp.GetServices<ISaveChangesInterceptor>();
            options.AddInterceptors(interceptors);

            options.UseNpgsql(connectionString);
        });
        services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());
        services.AddScoped<ApplicationDbContextInitializer>();

        var redisConnectionString = configuration.GetConnectionString("Redis");
        Guard.Against.Null(redisConnectionString, message: "Connection string 'Redis' not found.");
        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = redisConnectionString;
        });
        services.AddTransient<IDistributedCacheService, RedisCacheService>();

        services.AddTransient<IFileService, FileService>();

        services.AddMailService(configuration);

        services.AddAuthentication()
            .AddBearerToken(IdentityConstants.BearerScheme);
        services.AddAuthorizationBuilder();

        services
            .AddIdentityCore<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddApiEndpoints();
        
        services.AddSingleton(TimeProvider.System);
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthorizationBuilder()
            .AddPolicy(Policies.CanPurge, policy => policy.RequireRole(Roles.Administrator));

        services.AddQuartz(q =>
        {
            q.UsePersistentStore(opt =>
            {
                opt.UsePostgres(connectionString);
                opt.UseNewtonsoftJsonSerializer(cfg =>
                {
                });
            });
        });
        services.AddQuartzHostedService(opt =>
        {
            opt.WaitForJobsToComplete = true;
        });
        
        return services;
    }

    private static IServiceCollection AddMailService(this IServiceCollection services, IConfiguration configuration)
    {
        var mailSettingsSection = configuration.GetSection(MailSettings.Section);
        if (!mailSettingsSection.Exists())
        {
            return services;
        }

        services.Configure<MailSettings>(mailSettingsSection);
        services.AddTransient<IMailService, MailService>();

        return services;
    }
}