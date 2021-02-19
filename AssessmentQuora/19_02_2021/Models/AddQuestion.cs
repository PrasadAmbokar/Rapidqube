using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentQuora.Models
{
    public class AddQuestion
    {
        [Required]
        public int queId { get; set; }
        [Required]
        public string question { get; set; }
        [Required]
        public string topic { get; set; }
    }
}
