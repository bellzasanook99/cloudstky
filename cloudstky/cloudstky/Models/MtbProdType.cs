using System;
using System.Collections.Generic;

#nullable disable

namespace cloudstky.Models
{
    public partial class MtbProdType
    {
        public int Id { get; set; }
        public string NameTh { get; set; }
        public string NameEn { get; set; }
        public string AccName { get; set; }
        public bool? IsActive { get; set; }
    }
}
