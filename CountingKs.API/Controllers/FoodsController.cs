using Microsoft.AspNetCore.Mvc;
using CountingKs.Core.Stores;
using System.Linq;
using System.Collections.Generic;
using CountingKs.Core.DTOs;

namespace CountingKs.API.Controllers
{
    [Produces("application/json")]
    [Route("api/nutrition/foods")]
    public class FoodsController : BaseController
    {
        private readonly IFoodStore foodStore;        

        public FoodsController(IFoodStore foodStore)
        {
            this.foodStore = foodStore;
        }
        public IActionResult Get(bool includeMeasures = true)
        {
            var foodList = includeMeasures ?
                foodStore.GetAllFoodsWithMeasures()
                : foodStore.GetAllFoods(100);


            var results = foodList               
                .Select(x => ModelFactory.Create(x));

            return Ok(results);
        }

        [Route("{id}")]
        public IActionResult Get(int id)
        {
            var food = foodStore.GetFood(id);

            if(food == null)
            {
                return NotFound();
            }

            var model = ModelFactory.Create(food);

            return Ok(model);
        }
    }
}