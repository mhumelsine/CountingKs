﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CountingKs.API.Models
{
    public class FoodModel
    {
        public string Url { get; set; }
        public string Description { get; set; }
        public IEnumerable<MeasureModel> Measures { get; set; }
    }
}
