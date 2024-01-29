using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Job
    {
        public int JobId { get; set; }
        public int EmployerId { get; set; }

        public string Title { get; set; }

        public string JobType { get; set; }
        public string Description { get; set; }
        public string Requirements { get; set; }
        public string Location { get; set; }
        public string Salary { get; set; }
        public string Status { get; set; }


        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}