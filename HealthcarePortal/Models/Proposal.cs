using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Company name is required")]
        [MaxLength(100)]
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }

        [Required]
        [MaxLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Zip code is required")]
        [MaxLength(6)]
        [RegularExpression(@"^[1-9][0-9]{5}$", ErrorMessage = "Enter valid zip code")]
        [Display(Name = "Zip Code")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Proposal effective date is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Effective Date")]
        public DateTime ProposalEffectiveDate { get; set; }

        [Required(ErrorMessage = "Number of employee is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Number of employee must be greater than zero")]
        [Display(Name = "Number of Employee")]
        public int NumberOfEmployee { get; set; }

        [Required(ErrorMessage = "Select a admin user")]
        [ForeignKey("AdminUser")]
        public int AdminUserId { get; set; }

        [Display(Name = "Admin User")]
        public User AdminUser { get; set; }
    }
}