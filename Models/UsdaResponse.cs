using Newtonsoft.Json;
using Nutrition.Entities;

namespace Nutrition.Models;

public class UsdaResponse
{
    [JsonProperty("totalHits")]
    public int TotalHits { get; set; }

    [JsonProperty("currentPage")]
    public int CurrentPage { get; set; }

    [JsonProperty("totalPages")]
    public int TotalPages { get; set; }

    [JsonProperty("pageList")]
    public List<int> PageList { get; set; }

    [JsonProperty("foodSearchCriteria")]
    public FoodSearchCriteria FoodSearchCriteria { get; set; }

    [JsonProperty("foods")]
    public List<Food> Foods { get; set; }

    [JsonProperty("aggregations")]
    public Aggregations Aggregations { get; set; }
}

public class FoodSearchCriteria
{
    [JsonProperty("query")]
    public string Query { get; set; }

    // Add other properties as needed...
}

public class Aggregations
{
    [JsonProperty("dataType")]
    public Dictionary<string, int> DataType { get; set; }

    [JsonProperty("nutrients")]
    public Dictionary<string, int> Nutrients { get; set; }
}