using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentQuora.Models
{
    public class NewLogin
    {
        [Required(ErrorMessage="Enter UserName")]
        public string userName { get; set; }
        [Required(ErrorMessage = "Enter Password")]
        [DataType(DataType.Password)]
        public string password { get; set; }

        //[Required(ErrorMessage = "Enter Password")]
        //[DataType(DataType.Password)]
        //[Compare("password")]
        [NotMapped]
        [Required(ErrorMessage = "Confirm Password required")]
        [DataType(DataType.Password)]
        [CompareAttribute("password", ErrorMessage = "Password doesn't match.")]
        public string repassword { get; set; }

        [Required(ErrorMessage = "Enter name that can show on login page")]
        public string name { get; set; }
    }
}
