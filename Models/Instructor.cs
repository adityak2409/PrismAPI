using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        

        public string Name { get; set; }

        public string Bio { get; set; }
        public string Email { get; set; }
        public string Contact { get; set; }
  
        public string Status { get; set; }


        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}