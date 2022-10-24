using System;
using System.Collections.Generic;

#nullable disable

namespace cloudstky.Models
{
    public partial class TblProdGallery
    {
        public int Id { get; set; }
        public string ProdCode { get; set; }
        public string ImageName { get; set; }
        public string ImagePath { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
