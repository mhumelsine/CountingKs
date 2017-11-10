using Microsoft.AspNetCore.Mvc;
using CountingKs.Core.Stores;
using System.Linq;
using System.Collections.Generic;
using CountingKs.Core.DTOs;

namespace CountingKs.API.Controllers
{
    [Produces("application/json")]
    [Route("api/nutrition/foods", Name = RouteName.Foods)]
    public class FoodsController : Controller
    {
        private readonly IFoodStore foodStore;
        private readonly ModelFactory modelFactory;

        public FoodsController(IFoodStore foodStore, ModelFactory modelFactory)
        {
            this.foodStore = foodStore;
            this.modelFactory = modelFactory;
        }
        public IActionResult Get(bool includeMeasures = true)
        {
            var foodList = includeMeasures ?
                foodStore.GetAllFoodsWithMeasures()
                : foodStore.GetAllFoods(100);


            var results = foodList               
                .Select(x => modelFactory.Create(x));

            return Ok(results);
        }

        [Route("{id}", Name = RouteName.GetFoodById)]
        public IActionResult Get(int id)
        {
            var food = foodStore.GetFood(id);

            if(food == null)
            {
                return NotFound();
            }

            var model = modelFactory.Create(food);

            return Ok(model);
        }
    }
}