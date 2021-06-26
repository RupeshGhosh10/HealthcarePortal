using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.ViewModel
{
    public class UpdateViewModel
    {
        [Required(ErrorMessage = "First Name is required")]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "First name must contain only aplhabets")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [MaxLength(100)]
        [RegularExpression(@"^[a-zA-Z ]*$", ErrorMessage = "Last name must contain only aplhabets")]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile number is not valid")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }
    }
}