using Microsoft.Extensions.Logging;
using Nutrition.Models;

public class MainService : IMainService
{
    private readonly IFoodItemService _foodItemService;
    private readonly ILogger<MainService> _logger;

    public MainService(IFoodItemService foodItemService, ILogger<MainService> logger)
    {
        _foodItemService = foodItemService ?? throw new ArgumentNullException(nameof(foodItemService));
        _logger = logger;
    }

    public async Task Invoke()
    {
        Console.Write("Enter a food item: ");
        string foodItem = Console.ReadLine();

        var foodDto = await _foodItemService.GetFoodItemsFromUsda(foodItem);

        // Output details to the console
        PrintFoodDetails(foodDto);

    }
    static void PrintFoodDetails(FoodDto foodDto)
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
    }
}