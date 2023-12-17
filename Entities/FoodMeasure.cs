using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Nutrition.Entities
{

    public class FoodMeasure
    {
        [JsonProperty("disseminationText")]
        public string DisseminationText { get; set; }

        [JsonProperty("gramWeight")]
        public double GramWeight { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("modifier")]
        public string Modifier { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("measureUnitAbbreviation")]
        public string MeasureUnitAbbreviation { get; set; }

        [JsonProperty("measureUnitName")]
        public string MeasureUnitName { get; set; }

        [JsonProperty("measureUnitId")]
        public int MeasureUnitId { get; set; }
    }

}
