﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Industry
    {
        public int IndustryId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
        
        public string Status { get; set; }

        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
}