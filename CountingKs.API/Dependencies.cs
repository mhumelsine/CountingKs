using CountingKs.Core.Stores;
using CountingKs.Infrastructure.Stores;
using Microsoft.Extensions.DependencyInjection;

namespace CountingKs.API
{
    public static class Dependencies
    {
        public static void RegisterDependencies(this IServiceCollection services)
        {
            services.AddScoped<IFoodStore, EfFoodStore>();
            services.AddScoped<IMeasureStore, EfMeasureStore>();
        }
    }
}
