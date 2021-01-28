using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Models
{
    public class ShowAllInformation
    {
        [Display(Name = "Id")]
        [Key]
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string DeptName { get; set; }
        public DateTime DOB { get; set; }
        public string Designation { get; set; }
        public DateTime DOJ { get; set; }
        public string Degree { get; set; }
        public DateTime POY { get; set; }
        public string BankName { get; set; }
        public int AccNo { get; set; }
        public float GrossSalary { get; set; }
    }
}
