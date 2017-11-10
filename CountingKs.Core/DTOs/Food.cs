using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.DTOs
{
    public class Food
    {

        public Food()
        {
            this.Measures = new HashSet<Measure>();
        }
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Measure> Measures { get; set; }
    }
}
