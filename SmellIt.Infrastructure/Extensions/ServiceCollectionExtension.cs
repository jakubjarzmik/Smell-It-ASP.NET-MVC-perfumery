using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmellIt.Infrastructure.Persistence;
using SmellIt.Infrastructure.Repositories;
using SmellIt.Infrastructure.Seeders;
using SmellIt.Domain.Interfaces.Abstract;
using SmellIt.Domain.Interfaces;
using SmellIt.Infrastructure.Contexts;

namespace SmellIt.Infrastructure.Extensions;

public static class ServiceCollectionExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<SmellItDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("SmellItDb")).UseLazyLoadingProxies());

        services.AddDefaultIdentity<IdentityUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<SmellItDbContext>();

        services.AddScoped<IUserContext, UserContext>();

        services.AddScoped<Seeder>();

        //services.AddScoped<IBrandRepository, BrandRepository>();
        //services.AddScoped<IFragranceCategoryRepository, FragranceCategoryRepository>();
        services.Scan(scan => scan
            .FromAssemblyOf<BrandRepository>()
            .AddClasses(classes => classes.AssignableTo<IRepository>())
            .AsImplementedInterfaces()
            .WithScopedLifetime());
    }
}