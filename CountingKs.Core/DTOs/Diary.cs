using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.DTOs
{
    public class Diary
    {
        public int Id { get; set; }
        public DateTime CurrentDate { get; set; }
        public string Username { get; set; }

        public ICollection<DiaryEntry> Entries { get; set; }
    }
}
