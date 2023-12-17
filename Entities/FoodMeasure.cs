using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nutrition.Entities
{
    public class FoodMeasure
    {
        public string DisseminationText { get; set; }
        public double GramWeight { get; set; }
        public int Id { get; set; }
        public string Modifier { get; set; }
        public int Rank { get; set; }
        public string MeasureUnitAbbreviation { get; set; }
        public string MeasureUnitName { get; set; }
        public int MeasureUnitId { get; set; }
        // Add other properties as needed
    }
}
