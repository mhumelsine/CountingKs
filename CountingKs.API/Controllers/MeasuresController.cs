using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CountingKs.Core.Stores;

namespace CountingKs.API.Controllers
{
    [Produces("application/json")]
    [Route("api/nutrition/foods/{foodId}")]
    public class MeasuresController : BaseController
    {
        private readonly IMeasureStore measureStore;

        public MeasuresController(IMeasureStore measureStore)
        {
            this.measureStore = measureStore;
        }

        [Route("measures")]
        public IActionResult Get(int foodId)
        {
            var list = measureStore.GetMessuresForFood(foodId)
                .Select(x => ModelFactory.Create(x));

            return Ok(list);
        }

        [Route("measures/{id}")]
        public IActionResult Get(int foodId, int id)
        {
            var measure = measureStore.GetMeasure(id);

            if(measure == null || measure.FoodId != foodId)
            {
                return NotFound();
            }

            var model = ModelFactory.Create(measure);

            return Ok(model);
        }
    }
}