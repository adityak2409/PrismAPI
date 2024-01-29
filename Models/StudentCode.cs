using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class StudentCode
    {
        public int Id { get; set; }

        public string SName { get; set; }
        public int SRollNo { get; set; }
        public int CollegeId { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}