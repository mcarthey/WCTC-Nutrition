using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nutrition.Context;
using Nutrition.Mappers;
using Nutrition.Requesters;
using System;

namespace Nutrition
{
    public class Startup
    {
        public IServiceProvider ConfigureServices()
        {
            IServiceCollection services = new ServiceCollection();

            services.AddLogging(builder =>
            {
                builder.AddConsole();
                builder.AddFile("app.log");
            });

            // Add new lines of code here to register any interfaces and concrete services you create
            services.AddTransient<IMainService, MainService>();
            services.AddTransient<IFoodItemService, FoodItemService>();
            services.AddTransient<IFoodMapper, FoodMapper>();
            services.AddTransient<IUsdaRequester, UsdaRequester>();
            services.AddDbContextFactory<NutritionContext>();
            
            return services.BuildServiceProvider();
        }
    }
}
