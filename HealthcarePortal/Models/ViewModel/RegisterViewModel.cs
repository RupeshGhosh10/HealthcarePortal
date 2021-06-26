using HealthcarePortal.Models.Attribute;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.ViewModel
{
    public class RegisterViewModel
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

        [Required(ErrorMessage = "Email id is required")]
        [EmailAddress(ErrorMessage = "Enter valid e-mail address")]
        [MaxLength(100)]
        [UniqueEmail(ErrorMessage = "Email id already taken")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [MaxLength(10)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Mobile number is not valid")]
        [Display(Name = "Mobile Number")]
        public string MobileNumber { get; set; }

        [MaxLength(250)]
        public string Address { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must be 8 characters long")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password is required")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confirm password and password do not match")]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}