using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace cloudstky.Models
{
    public class MdlParam
    {
        public List<MtbUnitType> mtbUnits { get; set; }

        public TblProduct  tblProduct { get; set; }
    }


    public class MdlDataProdInput
    {
        public TblProduct tblProduct { get; set; }
        public IFormFile formFile { get; set; }
    }

    public class FileModel
    {
        public TblProduct data { get; set; }
        public string AccName { get; set; }
        public string ProdName { get; set; }
        public int? ProdUnit { get; set; }
        public decimal? Price { get; set; }
        public int ProdType { get; set; }
        public string ProdRemark { get; set; }
        public bool? IsActive { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }

        public List<IFormFile> FromFile { get; set; }
    }
}
