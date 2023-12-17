using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Logging;
using Nutrition.Entities;
using Nutrition.Mappers;
using Nutrition.Models;

namespace Nutrition.Requesters;

public class UsdaRequester : IUsdaRequester
{
    public const string ApiKey = "wlqWiro71mqm7HP0zOed2gNaE4QTbe83KcAPDvTH";
    private string _searchString;
    private readonly IFoodMapper _foodMapper;
    private readonly ILogger<UsdaRequester> _logger;

    public UsdaRequester(IFoodMapper foodMapper, ILogger<UsdaRequester> logger)
    {
        _foodMapper = foodMapper;
        _logger = logger;
    }

    public async Task<FoodDto> Invoke(string searchString)
    {
        _searchString = searchString;

        var food = await GetFoodFromUsda();

        var foodItemDto = _foodMapper.MapToDto(food);
        
        return foodItemDto;
    }

    private async Task<Food> GetFoodFromUsda()
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

                UsdaResponse fromUsda = new UsdaResponse();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON into Food model
                    fromUsda = JsonSerializer.Deserialize<UsdaResponse>(json);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }

                return fromUsda.Foods.FirstOrDefault();
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