using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class CollegeCode
    {
      public  int Id { get; set; }

      public string FName { get; set; }

        public string LName { get; set; }

        public string ContactNo { get; set; }
        public string Adress { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string Photo { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}