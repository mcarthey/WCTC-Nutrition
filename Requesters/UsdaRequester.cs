using System.Text.Json;
using Nutrition.Entities;
using Nutrition.Mappers;

namespace Nutrition.Requesters;

public class UsdaRequester : IUsdaRequester
{
    public const string ApiKey = "wlqWiro71mqm7HP0zOed2gNaE4QTbe83KcAPDvTH";
    private string _searchString;
    private readonly IFoodItemMapper _foodItemMapper;

    public UsdaRequester(IFoodItemMapper foodItemMapper)
    {
        _foodItemMapper = foodItemMapper;
    }

    public async Task<List<FoodItemDto>> Invoke(string searchString)
    {
        _searchString = searchString;

        var foodItems = await GetFoodItemFromUsda();

        List<FoodItemDto> foodItemDtos = new List<FoodItemDto>();
        foreach (var foodItem in foodItems)
        {
            foodItemDtos.Add(_foodItemMapper.Map(foodItem));
        }

        return foodItemDtos;
    }

    public async Task<List<FoodItem>> GetFoodItemFromUsda()
    {
        // Replace "YOUR_API_KEY" with your actual API key from the USDA FoodData Central API.
        string apiUrl = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={_searchString}&api_key={ApiKey}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            List<FoodItem> foodItems = new List<FoodItem>();
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize JSON into FoodItem model
                foodItems = JsonSerializer.Deserialize<List<FoodItem>>(json);
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }

            return foodItems;
        }
    }
}