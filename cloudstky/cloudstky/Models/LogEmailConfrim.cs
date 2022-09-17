using System;
using System.Collections.Generic;

#nullable disable

namespace cloudstky.Models
{
    public partial class LogEmailConfrim
    {
        public int Id { get; set; }
        public string AccName { get; set; }
        public string AccEmail { get; set; }
        public int? EmailCount { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
