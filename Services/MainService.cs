public class MainService : IMainService
{
    private readonly IFoodItemService _foodItemService;

    public MainService(IFoodItemService foodItemService)
    {
        _foodItemService = foodItemService ?? throw new ArgumentNullException(nameof(foodItemService));
    }

    public async Task Invoke()
    {
        Console.Write("Enter a food item: ");
        string foodItem = Console.ReadLine();

        var result = await _foodItemService.GetFoodItemsFromUsda(foodItem);

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