using Microsoft.Extensions.DependencyInjection;
using Project.Infrastructure.DAL;
using Project.Infrastructure.Tools;

namespace Project.Infrastructure.Utilities
{
    public static class ServiceProviderExtensions
    {
        public async static Task<IServiceProvider> SeedAsync(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var dbcontext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

            dbcontext.Database.EnsureCreated();
            await DbInitializer.SeedAsync(dbcontext);

            return serviceProvider;
        }
    }
}
