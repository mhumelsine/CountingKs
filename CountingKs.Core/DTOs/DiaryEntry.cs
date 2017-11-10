using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.DTOs
{
    public class DiaryEntry
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public int FoodItemId { get; set; }
        public int MesatureId { get; set; }
        public int DairyId { get; set; }

        public Diary Diary { get; set; }
        public Food FoodItem { get; set; }
        public Measure Measure { get; set; }
    }
}
