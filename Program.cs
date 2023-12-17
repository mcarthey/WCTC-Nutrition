using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Nutrition;

public class Program
{
    private static IServiceProvider _serviceProvider;

    private static async Task Main()
    {
        // Setup DI container
        var startup = new Startup();
        var _serviceProvider = startup.ConfigureServices();

        // Subscribe to the UnhandledException event
        AppDomain.CurrentDomain.UnhandledException += UnhandledExceptionHandler;

        // Resolve the main service
        var mainService = _serviceProvider.GetService<IMainService>();

        // Invoke the application
        await mainService?.Invoke();
    }

    private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs e)
    {
        // Retrieve the logger from the DI container
        var logger = _serviceProvider.GetService<ILogger<Program>>();

        // Log the exception
        var exception = (Exception) e.ExceptionObject;
        logger.LogError(exception, "Unhandled Exception");

        // Optionally perform any cleanup or shutdown actions
        Console.WriteLine("Performing cleanup...");
    }
}
