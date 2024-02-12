using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;
using PrismAPI.DAL;
using System.Data.Common;

namespace PrismAPI.DAL
{
    public class AchievementDAL
    {
        DbConnection conn = null;
        public AchievementDAL()
        {
            conn = new DbConnection();
        }

        public List<Achievement> GetAllAchievement()
        {
            List<Achievement> achievementList = new List<Achievement>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllAchievement", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Achievement achievement = new Achievement();

                achievement.AchievementId = Convert.ToInt32(dr["AchievementId"]);
                achievement.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                achievement.Title = Convert.ToString(dr["Title"]);
                achievement.Description = Convert.ToString(dr["Description"]);
                achievement.Certificate = Convert.ToString(dr["Certificate"]);
                achievement.Status = Convert.ToString(dr["Status"]);
                achievement.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                achievement.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                achievement.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                achievement.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                achievementList.Add(achievement);
            }
            con.Close();
            return achievementList;
        }


        /*public Achievement GetAchievementByEmail(string Email)
        {
            Achievement loginCode = new Achievement();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAchievementByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);
                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return loginCode;
        }*/



        public Achievement GetAchievementById(int AchievementId)
        {
            Achievement achievement = new Achievement();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAchievementById", con);
            cmd.Parameters.Add("AchievementId", SqlDbType.Int).Value = AchievementId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                achievement.AchievementId = Convert.ToInt32(dr["AchievementId"]);
                achievement.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                achievement.Title = Convert.ToString(dr["Title"]);
                achievement.Description = Convert.ToString(dr["Description"]);
                achievement.Certificate = Convert.ToString(dr["Certificate"]);
                achievement.Status = Convert.ToString(dr["Status"]);
                achievement.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                achievement.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                achievement.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                achievement.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);



            }
            con.Close();
            return achievement;
        }


        public string AddAchievement(Achievement achievement)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddAchievement", con);
            /*cmd.Parameters.Add("AchievementId", SqlDbType.Int).Value = achievement.AchievementId;*/
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = achievement.RegistrationId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = achievement.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = achievement.Description;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = achievement.Certificate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = achievement.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = achievement.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = achievement.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = achievement.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = achievement.UpdatedDate;



            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return Id.ToString();

        }

        [HttpPost]
        public string UpdateAchievement(Achievement achievement)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateAchievement", con);

            cmd.Parameters.Add("AchievementId", SqlDbType.Int).Value = achievement.AchievementId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = achievement.RegistrationId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = achievement.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = achievement.Description;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = achievement.Certificate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = achievement.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = achievement.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = achievement.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = achievement.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = achievement.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return achievement.AchievementId.ToString();

        }

        /*  public Loginc Loginc(string Email, string Password)
          {
              Loginc user = new Loginc();
              SqlConnection con = conn.OpenDbConnection();
              SqlCommand cmd = new SqlCommand("GetUserEmailAndPassword", con);
              cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
              cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
              cmd.CommandType = CommandType.StoredProcedure;
              SqlDataReader dr = cmd.ExecuteReader();
              if (dr.Read())
              {
                  user.Id = Convert.ToInt32(dr["Id"]);
                  //user.Role = Convert.ToString(dr["Role"]);
              }
              return user;
          }


          public OtpNo OtpNo(string Mobile)
          {
              OtpNo OtpNo = new OtpNo();
              SqlConnection con = conn.OpenDbConnection();
              SqlCommand cmd = new SqlCommand("GetUserOtp", con);
              cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = Mobile;

              cmd.CommandType = CommandType.StoredProcedure;
              SqlDataReader dr = cmd.ExecuteReader();
              if (dr.Read())
              {
                  OtpNo.Id = Convert.ToInt32(dr["Id"]);
                  //user.Role = Convert.ToString(dr["Role"]);
              }
              return OtpNo;
          }*/
        //public string UpdateFirstModel(FirstModel firstModel)
        //{
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("UpdateFirstModel", con);
        //    cmd.Parameters.Add("Id", SqlDbType.Int).Value = firstModel.Id;
        //    cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = firstModel.FirstName;
        //    cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = firstModel.LastName;
        //    cmd.Parameters.Add("DOB", SqlDbType.NVarChar).Value = firstModel.DOB;





        //    //cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = firstModel.CreatedBy;
        //    //cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = firstModel.CreatedDate;
        //    //cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = firstModel.UpdatedBy;
        //    //cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = firstModel.UpdatedDate;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    object result = cmd.ExecuteScalar();

        //    con.Close();
        //    if (result.ToString() == "0")
        //    {
        //        return "Failed";
        //    }
        //    return "Success";
        //}


        public string DeleteAchievement(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteAchievement", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }
    }
}