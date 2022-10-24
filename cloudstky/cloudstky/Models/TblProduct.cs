using System;
using System.Collections.Generic;

#nullable disable

namespace cloudstky.Models
{
    public partial class TblProduct
    {
        public int Id { get; set; }
        public string AccName { get; set; }
        public string ProdCode { get; set; }
        public string ProdName { get; set; }
        public int? ProdUnit { get; set; }
        public int? ProdUnitType { get; set; }
        public decimal? Price { get; set; }
        public int? ProdType { get; set; }
        public string ProdRemark { get; set; }
        public bool? IsActive { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
