using CountingKs.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using CountingKs.Core.DTOs;
using CountingKs.Infrastructure.Data;
using System.Linq;

namespace CountingKs.Infrastructure.Stores
{
    public class EfMeasureStore : IMeasureStore
    {
        private readonly CountingKsContext context;

        public EfMeasureStore(CountingKsContext context)
        {
            this.context = context;
        }
        public Measure GetMeasure(int id)
        {
            return context.Measures.Find(id);
        }

        public IEnumerable<Measure> GetMessuresForFood(int foodId)
        {
            return context.Measures
                .Where(x => x.FoodId == foodId)
                .ToList();
        }
    }
}
