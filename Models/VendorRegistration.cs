using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class VendorRegistration
    {
        public int VendorRegistrationId { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string EmailStatus { get; set; }

        public string OtpNo { get; set; }

        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
    public class Loginv
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int VendorRegistrationId { get; set; }
        public string Role { get; set; }
    }

}
//public class OtpNo
//{
//    public string Mobile { get; set; }
//    public int Id { get; set; }

//}
