using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentQuora.Models
{
    public class FirstPage
    {
        [Required]
        public int QueId { get; set; }
        [Required]
        public int AnsId { get; set; }
        public string Question { get; set; }
        public string Answer { get; set; }
    }
}
