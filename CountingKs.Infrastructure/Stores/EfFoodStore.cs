using CountingKs.Core.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using CountingKs.Core.DTOs;
using CountingKs.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CountingKs.Infrastructure.Stores
{
    public class EfFoodStore : IFoodStore
    {
        private readonly CountingKsContext context;

        public EfFoodStore(CountingKsContext context)
        {
            this.context = context;
        }
        public IEnumerable<Food> FindFoodsWithMeasures(string searchString)
        {
            return context.Foods.Include(x => x.Measures).ToList();
        }

        public IEnumerable<Food> GetAllFoods(int limit)
        {
            return context.Foods
                .Take(limit)
                .ToList();
        }

        public IEnumerable<Food> GetAllFoodsWithMeasures()
        {
            return context.Foods
                .Include(x => x.Measures)
                .ToList();
        }

        public Food GetFood(int id)
        {
            return context.Foods.Find(id);
        }
    }
}
