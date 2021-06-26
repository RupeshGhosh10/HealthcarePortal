using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.ViewModel
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [EmailAddress(ErrorMessage = "Enter valid e-mail address")]
        [Display(Name = "Email Id")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remeber me?")]
        public bool RemeberMe { get; set; }
    }
}