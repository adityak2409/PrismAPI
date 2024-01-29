using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class CV
    {
        public int CVId { get; set; }
        public int RegistrationId { get; set; }
       
        public string CVPDF { get; set; }
        public string Status { get; set; }


        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    }
}