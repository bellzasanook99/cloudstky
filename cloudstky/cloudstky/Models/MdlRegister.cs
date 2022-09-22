using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace cloudstky.Models
{
    public class MdlRegister
    {



        [Required(ErrorMessage = "UserName is required")]
        public string AccName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string AccPwd { get; set; }

        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [Compare("AccPwd", ErrorMessage = "Password doesn't match.")]
        public string AccCPwd { get; set; }

        [Required(ErrorMessage = "Email is required")]
    //    [RegularExpression(@"^([A-Za-z0-9][^'!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ][a-zA-z0- 
    //9-._][^!&\\#*$%^?<>()+=:;`~\[\]{}|/,₹€@ ]*\@[a-zA-Z0-9][^!&@\\#*$%^?<> 
    //    ()+=':;~`.\[\]{}|/,₹€ ]*\.[a-zA-Z]{2,6})$", ErrorMessage = "Please enter a valid Email")]
        public string AccEmail { get; set; }

        public string CompanyName { get; set; }

        public string AccTel { get; set; }
    }
}
