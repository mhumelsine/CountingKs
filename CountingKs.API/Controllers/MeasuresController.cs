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
    public class MeasuresController : Controller
    {
        private readonly IMeasureStore measureStore;
        private readonly ModelFactory modelFactory;

        public MeasuresController(IMeasureStore measureStore, ModelFactory modelFactory)
        {
            this.measureStore = measureStore;
            this.modelFactory = modelFactory;
        }

        [Route("measures", Name = RouteName.Measures)]
        public IActionResult Get(int foodId)
        {
            var list = measureStore.GetMessuresForFood(foodId)
                .Select(x => modelFactory.Create(x));

            return Ok(list);
        }

        [Route("measures/{id}", Name = RouteName.GetMeasureById)]
        public IActionResult Get(int foodId, int id)
        {
            var measure = measureStore.GetMeasure(id);

            if(measure == null || measure.FoodId != foodId)
            {
                return NotFound();
            }

            var model = modelFactory.Create(measure);

            return Ok(model);
        }
    }
}