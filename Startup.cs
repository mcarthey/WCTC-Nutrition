﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nutrition.Context;
using Nutrition.Mappers;
using Nutrition.Requesters;
using Nutrition.Services;

namespace Nutrition;

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

        services.AddHttpClient("UsdaHttpClient", client =>
        {
            client.BaseAddress = new Uri("https://api.example.com/");
            client.Timeout = TimeSpan.FromSeconds(30); // Set a 30-second timeout (adjust as needed)
            client.DefaultRequestHeaders.Host = "api.nal.usda.gov";
            // Additional configuration...
        });

        // Add new lines of code here to register any interfaces and concrete services you create
        services.AddTransient<IMainService, MainService>();
        services.AddTransient<IFoodItemService, FoodItemService>();
        services.AddTransient<IFoodMapper, FoodMapper>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();
        services.AddTransient<IUsdaRequester, UsdaRequester>();
        services.AddDbContextFactory<NutritionContext>();

        return services.BuildServiceProvider();
    }
}
