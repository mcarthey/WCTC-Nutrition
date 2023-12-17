using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Nutrition.Entities
{
    public class Food
    {
        [JsonProperty("fdcId")]
        public int FdcId { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("commonNames")]
        public string CommonNames { get; set; }

        [JsonProperty("foodNutrients")]
        public List<FoodNutrient> FoodNutrients { get; set; }

        [JsonProperty("foodMeasures")]
        public List<FoodMeasure> FoodMeasures { get; set; }

        // Add other properties as needed
    }


}
