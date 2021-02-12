using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Models
{
    public class AddEmployeeDetails
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        //public int EmpId { get; set; }
        [Required]
        public string EmpName { get; set; }
        [Required]
        public string DeptId { get; set; }

        public List<SelectListItem> getDeptName = new List<SelectListItem>();
        //{
        //    new SelectListItem { Value = "1", Text = "Account" },
        //    new SelectListItem { Value = "2", Text = "Finance" },
        //    new SelectListItem { Value = "3", Text = "HR"  },
        //    new SelectListItem { Value = "4", Text = "IT"  },
        //    new SelectListItem { Value = "5", Text = "Marketing"  },
        //    new SelectListItem { Value = "6", Text = "Sales"  },
        //};
        public string DeptName { get; set; }

        

    }
}
