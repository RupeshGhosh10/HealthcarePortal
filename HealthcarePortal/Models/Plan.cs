using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models
{
    public class Plan
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Plan name is required")]
        [MaxLength(100)]
        [Display(Name = "Plan Name")]
        public string PlanName { get; set; }

        [Required(ErrorMessage = "Sum insured is required")]
        [DataType(DataType.Currency)]
        [Range(50000 , int.MaxValue, ErrorMessage = "Sum insured must be greater than 1 lakh")]
        [Display(Name = "Sum Insured")]
        public double SumInsured { get; set; }
    }
}