using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class EmployeeCode
    {
        public int Id { get; set; }
        public BranchCode BranchCode { get; set; }
        public int BranchId { get; set; }
        
        public string EmpName { get; set; }
        public string BirthDate { get; set; }
        public string Salary { get; set; }

        public string Photo { get; set; }

        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
    


}
}