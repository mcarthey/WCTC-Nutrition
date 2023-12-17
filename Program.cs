using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Nutrition.Context;
using Nutrition;

public class Program
{
    static void Main()
    {
        // Setup DI container
        var startup = new Startup();
        var serviceProvider = startup.ConfigureServices();

        // Resolve the main service
        var mainService = serviceProvider.GetService<IMainService>();

        // Invoke the application
        mainService?.Invoke();
    }

}
