using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AssessmentFinal.Models
{
    public class DeptDDL
    {
        public List<SelectListItem> Departments { get; set; }

    }
}
