using HealthcarePortal.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.Attribute
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        private readonly HealthcarePortalContext _db = new HealthcarePortalContext();

        public override bool IsValid(object value)
        {
            string email = (string)value;
            return !(_db.Users.Any(x => x.Email == email));
        }
    }
}