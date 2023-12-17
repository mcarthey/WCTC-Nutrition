using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Nutrition.Entities;
using Nutrition.Helpers;
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
    private readonly MemoryCache _responseCache;

    public UsdaRequester(IFoodMapper foodMapper, IHttpClientFactory httpClientFactory, ILogger<UsdaRequester> logger)
    {
        _foodMapper = foodMapper;
        _httpClientFactory = httpClientFactory;
        _logger = logger;

        _responseCache = new MemoryCache(new MemoryCacheOptions());
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

        if (_responseCache.TryGetValue(_searchString, out var cachedResponse) && cachedResponse is Task<Food> taskResponse)
        {
            ConsoleHelper.WriteLineWithColor("Response retrieved from cache", ConsoleColor.DarkYellow);
            return await taskResponse; // Await the cached task
        }

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

                var food = usdaResponse.Foods.FirstOrDefault();

                // Cache the response for future use
                _responseCache.Set(_searchString, Task.FromResult(food), new MemoryCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(10) // Set an absolute expiration time
                });

                return food;
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