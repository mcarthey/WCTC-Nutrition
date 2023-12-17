using Nutrition.Entities;
using Nutrition.Models;

namespace Nutrition.Requesters;

public interface IUsdaRequester
{
    Task<FoodDto> Invoke(string searchString);
}
