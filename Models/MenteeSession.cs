using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class MenteeSession
    {

        public int MenteeSessionId { get; set; }

        public int SessionId { get; set; }

        public int MenteeProfileId { get; set; }
       
        public string Status { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }

        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
       
    }
}