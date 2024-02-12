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
    public class UserSkillDAL
    {
        DbConnection conn = null;
        public UserSkillDAL()
        {
            conn = new DbConnection();
        }

        public List<UserSkill> GetAllUserSkill()
        {

            List<UserSkill> userskillList = new List<UserSkill>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserSkill userskill = new UserSkill();
                userskill.Skills = new Skills();
                userskill.UserSkillId = Convert.ToInt32(dr["UserSkillId"]);
                userskill.Skills.SkillsId = Convert.ToInt32(dr["SkillsId"]);
                userskill.Skills.Title = Convert.ToString(dr["Title1"]);
                userskill.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                userskill.Certificate = Convert.ToString(dr["Certificate"]);
                userskill.Status = Convert.ToString(dr["Status"]);
                userskill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                userskill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                userskill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                userskill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                userskillList.Add(userskill);
            }
            con.Close();
            return userskillList;
        }


        /*public UserSkill GetUserSkillByEmail(string Email)
        {
            UserSkill loginCode = new UserSkill();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserSkillByEmail", con);
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
        }

*/

        public UserSkill GetUserSkillById(int UserSkillId)
        {
            UserSkill userskill = new UserSkill();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserSkillById", con);
            cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = UserSkillId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                userskill.Skills = new Skills();
                userskill.UserSkillId = Convert.ToInt32(dr["UserSkillId"]);
                userskill.Skills.SkillsId = Convert.ToInt32(dr["SkillsId"]);
                userskill.Skills.Title = Convert.ToString(dr["Title1"]);
                userskill.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                userskill.Certificate = Convert.ToString(dr["Certificate"]);
                userskill.Status = Convert.ToString(dr["Status"]);
                userskill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                userskill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                userskill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                userskill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return userskill;
        }


        public string AddUserSkill(UserSkill userskill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserSkill", con);
            //cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = userskill.UserSkillId;
            cmd.Parameters.Add("SkillsId", SqlDbType.Int).Value = userskill.Skills.SkillsId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userskill.RegistrationId;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = userskill.Certificate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userskill.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userskill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userskill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userskill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userskill.UpdatedDate;


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
        public string UpdateUserSkill(UserSkill userskill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserSkill", con);
            cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = userskill.UserSkillId;
            cmd.Parameters.Add("SkillsId", SqlDbType.Int).Value = userskill.Skills.SkillsId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = userskill.RegistrationId;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = userskill.Certificate;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userskill.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userskill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userskill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userskill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userskill.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return userskill.UserSkillId.ToString();

        }

        /*public Loginc Loginc(string Email, string Password)
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


        public string DeleteUserSkill(int UserSkillId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteUserSkill", con);
            cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = UserSkillId;
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