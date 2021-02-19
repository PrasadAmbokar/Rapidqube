using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentQuora.Models
{
    public class AddAnswer
    {
        [Required]
        public int ansId { get; set; }
        [Required]
        public string answer { get; set; }
        [Required]
        public int queId { get; set; }
    }
}
