using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.ViewModel
{
    public class SelectPlanViewModel
    {
        [Required(ErrorMessage = "Select a plan")]
        public int PlanId { get; set; }

        public IEnumerable<Plan> Plans { get; set; }
    }
}