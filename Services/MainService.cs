public class MainService : IMainService
{
    private readonly IFoodItemService _foodItemService;

    public MainService(IFoodItemService foodItemService)
    {
        _foodItemService = foodItemService ?? throw new ArgumentNullException(nameof(foodItemService));
    }

    public void Invoke()
    {
        Console.Write("Enter a food item: ");
        string foodItem = Console.ReadLine();

        var result = _foodItemService.GetFoodItemDetails(foodItem);

        Console.WriteLine($"Food Item: {result.Description}");
        Console.WriteLine("Nutrients:");
        foreach (var nutrient in result.Nutrients)
        {
            Console.WriteLine($"- {nutrient.Name}: {nutrient.Value} {nutrient.Unit}");
        }
    }
}