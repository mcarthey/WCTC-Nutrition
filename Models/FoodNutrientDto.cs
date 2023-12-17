using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nutrition.Entities;

namespace Nutrition.Models
{
    public class FoodNutrientDto
    {
        public long NutrientId { get; set; }
        public string NutrientName { get; set; }

        public UnitName NutrientUnit { get; set; }

        public double NutrientValue { get; set; }
        // Add other properties as needed
    }
}
