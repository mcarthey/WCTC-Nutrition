using Microsoft.Extensions.Logging;
using Nutrition.Helpers;
using Nutrition.Models;
using Nutrition.Services;

public class MainService : IMainService
{
    private readonly IFoodItemService _foodItemService;
    private readonly IAuthenticationService _authenticationService;
    private readonly ILogger<MainService> _logger;

    public MainService(IFoodItemService foodItemService, IAuthenticationService authenticationService, ILogger<MainService> logger)
    {
        _foodItemService = foodItemService ?? throw new ArgumentNullException(nameof(foodItemService));
        _authenticationService = authenticationService;
        _logger = logger;
    }

    public async Task Invoke()
    {
        // Authenticate User before moving on in the application
        _authenticationService.Invoke();

        ConsoleHelper.WriteLineWithColor("An empty search value will exit", ConsoleColor.DarkBlue);
        ConsoleHelper.WriteLineWithColor("Enter a food item: ", ConsoleColor.DarkGreen);
        var foodItem = Console.ReadLine();

        while (!string.IsNullOrWhiteSpace(foodItem))
        {
            var foodDto = await _foodItemService.GetFoodItemsFromUsda(foodItem);

            // Output details to the console
            PrintFoodDetails(foodDto);

            ConsoleHelper.WriteLineWithColor("An empty search value will exit", ConsoleColor.DarkBlue);
            ConsoleHelper.WriteLineWithColor("Enter a food item: ", ConsoleColor.DarkGreen);
            foodItem = Console.ReadLine();
        }
    }

    private static void PrintFoodDetails(FoodDto foodDto)
    {
        Console.WriteLine($"FDC ID: {foodDto.FdcId}");
        Console.WriteLine($"Description: {foodDto.Description}");

        Console.WriteLine("Nutrients:");
        foreach (var nutrient in foodDto.FoodNutrients)
        {
            Console.Write($"  ({nutrient.NutrientId})");
            Console.WriteLine($" {nutrient.NutrientName} {nutrient.NutrientValue} {nutrient.NutrientUnit}");
            // Print other nutrient properties
        }

        Console.WriteLine("Measures:");
        foreach (var measure in foodDto.FoodMeasures)
        {
            Console.WriteLine($"  Dissemination Text: {measure.DisseminationText}");
            Console.WriteLine($"  Gram Weight: {measure.GramWeight}");
            // Print other measure properties
        }

        // Print other properties as needed
        Console.WriteLine();
    }
}
