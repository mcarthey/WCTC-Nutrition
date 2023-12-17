using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Nutrition.Entities;

public class FoodNutrient
{
    [JsonProperty("nutrientId")]
    public int NutrientId { get; set; }

    [JsonProperty("nutrientName")]
    public string NutrientName { get; set; }

    [JsonProperty("nutrientNumber")]
    public string NutrientNumber { get; set; }

    [JsonProperty("unitName")]
    public string UnitName { get; set; }

    [JsonProperty("value")]
    public double Value { get; set; }

    [JsonProperty("rank")]
    public int Rank { get; set; }

    [JsonProperty("indentLevel")]
    public int IndentLevel { get; set; }

    [JsonProperty("foodNutrientId")]
    public int FoodNutrientId { get; set; }

    // Add other properties as needed

}