using System;
using System.Collections.Generic;

#nullable disable

namespace cloudstky.Models
{
    public partial class TblAccount
    {
        public int Id { get; set; }
        public string AccName { get; set; }
        public string AccPwd { get; set; }
        public string AccEmail { get; set; }
        public string AccTel { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? ModifyTime { get; set; }
        public DateTime? CreatedTime { get; set; }
    }
}
