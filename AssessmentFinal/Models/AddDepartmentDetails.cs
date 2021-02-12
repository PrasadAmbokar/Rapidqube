using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Models
{
    public class AddDepartmentDetails
    {
        [Required]
        public string DeptName { get; set; }
    }
}
