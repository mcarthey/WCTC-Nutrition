using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Nutrition.Entities;
using Nutrition.Mappers;

namespace Nutrition.Requesters;

public class UsdaRequester : IUsdaRequester
{
    public const string ApiKey = "wlqWiro71mqm7HP0zOed2gNaE4QTbe83KcAPDvTH";
    private string _searchString;
    private readonly IFoodItemMapper _foodItemMapper;
    private readonly ILogger<UsdaRequester> _logger;

    public UsdaRequester(IFoodItemMapper foodItemMapper, ILogger<UsdaRequester> logger)
    {
        _foodItemMapper = foodItemMapper;
        _logger = logger;
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

    public async Task<List<Food>> GetFoodItemFromUsda()
    {
        // Replace "YOUR_API_KEY" with your actual API key from the USDA FoodData Central API.
        string apiUrl = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={_searchString}&api_key={ApiKey}";

        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = TimeSpan.FromSeconds(30); // Set a 30-second timeout (adjust as needed)
                client.DefaultRequestHeaders.Host = "api.nal.usda.gov";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                List<Food> foodItems = new List<Food>();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON into Food model
                    foodItems = JsonSerializer.Deserialize<List<Food>>(json);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }

                return foodItems;
            }
        }
        catch (Exception e)
        {
            _logger.Log(LogLevel.Critical, e, "An error occurred");
            Console.WriteLine(e);
            throw;
        }
    }
}