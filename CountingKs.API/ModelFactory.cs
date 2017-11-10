using CountingKs.API.Models;
using CountingKs.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingKs.API
{
    public class ModelFactory
    {
        public FoodModel Create(Food food)
        {
            return new FoodModel
            {
                Description = food.Description,
                Measures = food.Measures.Select(x => Create(x))
            };
        }

        public MeasureModel Create(Measure measure)
        {
            return new MeasureModel
            {
                Calories = measure.Calories,
                Description = measure.Description
            };
        }
    }
}
