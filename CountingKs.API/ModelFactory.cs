using CountingKs.API.Models;
using CountingKs.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CountingKs.API
{
    public class ModelFactory
    {
        private readonly IUrlHelper urlHelper;
        public ModelFactory(IUrlHelper urlHelper)
        {
            this.urlHelper = urlHelper;
        }
        public FoodModel Create(Food food)
        {
            return new FoodModel
            {
                Url = urlHelper.RouteUrl(RouteName.GetFoodById, new { Id = food.Id }),
                Description = food.Description,
                Measures = food.Measures.Select(x => Create(x))
            };
        }

        public MeasureModel Create(Measure measure)
        {
            return new MeasureModel
            {
                Url = urlHelper.RouteUrl(RouteName.GetMeasureById, new { foodId = measure.FoodId, id = measure.Id }),
                Calories = measure.Calories,
                Description = measure.Description
            };
        }
    }
}
