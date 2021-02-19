using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentQuora.Models
{
    public class LoginPage
    {
        [Required(ErrorMessage = "Enter Username")]
        [Display(Name = "Enter Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Enter Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        [Display(Name = "Enter Name")]
        public string Name { get; set; }
    }
}
