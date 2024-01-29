using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Employer
    {
        public int EmployerId { get; set; }
        public int VendorId { get; set; }

        public string CompanyName { get; set; }

        public string Industry { get; set; }

        public string Contact { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }


        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}