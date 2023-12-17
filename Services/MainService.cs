using Microsoft.Extensions.Logging;

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

        List<FoodItemDto> result;
        try
        {
             result = await _foodItemService.GetFoodItemsFromUsda(foodItem);
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, e, "An error occurred");
            Console.WriteLine(e);
            throw;
        }

        foreach (var item in result)
        {
            Console.WriteLine($"Food Item: {item.Description}");
            Console.WriteLine("Nutrients:");
            foreach (var nutrient in item.Nutrients)
            {
                Console.WriteLine($"- {nutrient.Name}: {nutrient.Unit} {nutrient.Value}");
            }
        }
    }
}