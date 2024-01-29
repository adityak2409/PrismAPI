using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Reviews
    {
        public int ReviewsId { get; set; }
        public int RegistrationId { get; set; }
        public int CourseId { get; set; }

        public string Rating { get; set; }

        public string Comment { get; set; }

      
        public string Status { get; set; }


        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}