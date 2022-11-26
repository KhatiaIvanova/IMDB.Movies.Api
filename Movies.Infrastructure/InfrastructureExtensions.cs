using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Contracts.Interfaces.Repositories;
using Movies.Application.Interfaces;
using Movies.Infrastructure.ApiServices;
using Movies.Persistence.DbContexts;
using Movies.Persistence.Repositories;
namespace Movies.Infrastructure;

public static class InfrastructureExtensions
{
    public static void AddInfrastructure(this IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();

        services.AddDbContext<SpaceIMDBDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));


        services.AddScoped<IWatchHistoryItemRepository, WatchHistoryItemRepository>();
        services.AddScoped<IIMdbSearchService, ImdbSearchService>();
    }
}