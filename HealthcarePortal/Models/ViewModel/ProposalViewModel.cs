using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthcarePortal.Models.ViewModel
{
    public class ProposalViewModel
    {
        public Proposal Proposal { get; set; }

        public IEnumerable<User> AdminUser { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}