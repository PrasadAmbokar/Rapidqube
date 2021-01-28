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
    }
}
