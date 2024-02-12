using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrismAPI.Models
{
    public class Achievement
    {
        public int AchievementId { get; set; }
        public int RegistrationId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Certificate { get; set; }
        public string Status { get; set; }
        public string CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string UpdatedBy { get; set; }
    }
    /*public class Loginc
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public int Id { get; set; }
        public string Role { get; set; }
    }
    public class OtpNo
    {
        public string Mobile { get; set; }
        public int Id { get; set; }

    }*/
}