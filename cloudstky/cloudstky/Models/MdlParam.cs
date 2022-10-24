using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string AccName { get; set; }

        [Required(ErrorMessage = "ProdName is Required")]
        public string ProdName { get; set; }


        [Required(ErrorMessage = "ProdUnit is Required")]
        [RegularExpression("^[+]?\\d*$", ErrorMessage = "*")]
        public int? ProdUnit { get; set; }


        [Required(ErrorMessage = "Price is Required")]
        [RegularExpression("^[+]?\\d*$", ErrorMessage = "*")]
        public decimal? Price { get; set; }


        public int ProdType { get; set; }

        public int ProdUnitType { get; set; }
        

        [Required(ErrorMessage = "ProdRemark is Required")]
        public string ProdRemark { get; set; }

        public bool? IsActive { get; set; }
        public string ModifyBy { get; set; }
        public DateTime? ModifyTime { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? CreatedTime { get; set; }


        [Required(ErrorMessage = "Please select a file.")]
        [DataType(DataType.Upload)]
        public List<IFormFile> FromFile { get; set; }
    }

    public class Error
    {
        public Error(string key, string message)
        {
            Key = key;
            Message = message;
        }

        public string Key { get; set; }
        public string Message { get; set; }
    }

    public class MdlProdview
    {
        public TblProduct tblProduct { get; set; }
        public List<TblProdGallery> tblProdGalleries { get; set; }
    }
}
