using System;
using System.Collections.Generic;

#nullable disable

namespace cloudstky.Models
{
    public partial class MtbUnitType
    {
        public int Id { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public decimal? Amount { get; set; }
        public string AccName { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
