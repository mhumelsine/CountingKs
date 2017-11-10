using CountingKs.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.Stores
{
    public interface IMeasureStore
    {
        IEnumerable<Measure> GetMessuresForFood(int foodId);
        Measure GetMeasure(int id);
    }
}
