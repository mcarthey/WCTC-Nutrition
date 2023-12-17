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
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly ILogger<UsdaRequester> _logger;

    public UsdaRequester(IFoodMapper foodMapper, IHttpClientFactory httpClientFactory, ILogger<UsdaRequester> logger)
    {
        _foodMapper = foodMapper;
        _httpClientFactory = httpClientFactory;
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
            using (HttpClient client = _httpClientFactory.CreateClient("UsdaHttpClient"))
            {

                HttpResponseMessage response = await client.GetAsync(apiUrl);

                UsdaResponse usdaResponse = new UsdaResponse();
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    // Deserialize JSON into Food model
                    usdaResponse = UsdaResponse.FromJson(json);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                }

                return usdaResponse.Foods.FirstOrDefault();
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