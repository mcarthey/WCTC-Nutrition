using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System;
using Nutrition.Context;
using Nutrition;
using Microsoft.Extensions.Logging;

public class Program
{
    private static IServiceProvider _serviceProvider;

    static void Main()
    {
        // Setup DI container
        var startup = new Startup();
        var _serviceProvider = startup.ConfigureServices();

        // Subscribe to the UnhandledException event
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

        // Resolve the main service
        var mainService = _serviceProvider.GetService<IMainService>();

        // Invoke the application
        mainService?.Invoke();
    }

    private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        // Retrieve the logger from the DI container
        var logger = _serviceProvider.GetService<ILogger<Program>>();

        // Log the exception
        Exception exception = (Exception)e.ExceptionObject;
        logger.LogError(exception, "Unhandled Exception");

        // Optionally perform any cleanup or shutdown actions
        Console.WriteLine("Performing cleanup...");
    }

}
