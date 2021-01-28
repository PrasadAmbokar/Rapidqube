using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Models
{
    public class EditEmployee
    {
        [Display(Name = "Id")]
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public int DeptId { get; set; }

        public string DOB { get; set; }
        public string DeptName { get; set; }
        public string Designation { get; set; }
        public float GrossSalary { get; set; }
        public int BankAccount { get; set; }
        public string BankName { get; set; }
        public string Degree { get; set; }
        public string POY { get; set; }
        public string DOJ { get; set; }
    }
}
