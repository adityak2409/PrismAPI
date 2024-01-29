using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class SocialMedia
    {
        public int SocialMediaId { get; set; }
        public int RegistrationId { get; set; }

        public string Facebook { get; set; }

        public string Instagram { get; set; }

        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string Status { get; set; }
       

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}