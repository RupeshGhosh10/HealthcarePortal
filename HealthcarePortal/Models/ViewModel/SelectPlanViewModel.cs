using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.ViewModel
{
    public class SelectPlanViewModel
    {
        public Plan Plan { get; set; }

        public IEnumerable<Plan> Plans { get; set; }
    }
}