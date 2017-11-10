using System;
using System.Collections.Generic;
using System.Text;

namespace CountingKs.Core.DTOs
{
    public class ApiUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string AppId { get; set; }

    }
}
