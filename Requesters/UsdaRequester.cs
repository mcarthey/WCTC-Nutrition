using System.Text.Json;
using Nutrition.Models;

namespace Nutrition.Requesters;

public class UsdaRequester
{
    public async Task Invoke()
    {
        Console.Write("Enter a food item: ");
        string foodItem = Console.ReadLine();

        // Replace "YOUR_API_KEY" with your actual API key from the USDA FoodData Central API.
        string apiKey = "wlqWiro71mqm7HP0zOed2gNaE4QTbe83KcAPDvTH";
        string apiUrl = $"https://api.nal.usda.gov/fdc/v1/foods/search?query={foodItem}&api_key={apiKey}";

        using (HttpClient client = new HttpClient())
        {
            HttpResponseMessage response = await client.GetAsync(apiUrl);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                // Deserialize JSON into FoodItem model
                var foodItems = JsonSerializer.Deserialize<FoodItemsResponse>(json);

                // Display relevant information
                foreach (var item in foodItems.FoodItems)
                {
                    Console.WriteLine($"Food Item: {item.Description}");
                    Console.WriteLine("Nutrients:");
                    foreach (var nutrient in item.Nutrients)
                    {
                        Console.WriteLine($"- {nutrient.Name}: {nutrient.Value} {nutrient.Unit}");
                    }
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
            }
        }
    }
}