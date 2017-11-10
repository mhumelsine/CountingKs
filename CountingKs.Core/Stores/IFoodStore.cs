using CountingKs.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IFoodStore
    {
        IEnumerable<Food> GetAllFoods(int limit);
        IEnumerable<Food> GetAllFoodsWithMeasures();
        IEnumerable<Food> FindFoodsWithMeasures(string searchString);
        Food GetFood(int id);
    }
}
