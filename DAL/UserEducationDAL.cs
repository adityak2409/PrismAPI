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
    public class UserEducationDAL
    {
        DbConnection conn = null;
        public UserEducationDAL()
        {
            conn = new DbConnection();
        }

        public List<UserEducation> GetAllUserEducation()
        {
            List<UserEducation> usereducationList = new List<UserEducation>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserEducation", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserEducation usereducation = new UserEducation();

                usereducation.UserEducationId = Convert.ToInt32(dr["UserEducationId"]);
                usereducation.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                usereducation.Title = Convert.ToString(dr["Title"]);
                usereducation.Description = Convert.ToString(dr["Description"]);
                usereducation.University = Convert.ToString(dr["University"]);
                usereducation.College = Convert.ToString(dr["College"]);

                usereducation.Status = Convert.ToString(dr["Status"]);

                usereducation.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                usereducation.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                usereducation.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                usereducation.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                usereducationList.Add(usereducation);
            }
            con.Close();
            return usereducationList;
        }


        /* public UserEducation GetLoginCodeByEmail(string Email)
         {
             LoginCode loginCode = new LoginCode();

             SqlConnection con = conn.OpenDbConnection();
             SqlCommand cmd = new SqlCommand("GetUserLoginByEmail", con);
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



        public UserEducation GetUserEducationById(int UserEducationId)
        {
            UserEducation usereducation = new UserEducation();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserEducationById", con);
            cmd.Parameters.Add("UserEducationId", SqlDbType.Int).Value = UserEducationId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                usereducation.UserEducationId = Convert.ToInt32(dr["UserEducationId"]);
                usereducation.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                usereducation.Title = Convert.ToString(dr["Title"]);
                usereducation.Description = Convert.ToString(dr["Description"]);
                usereducation.University = Convert.ToString(dr["University"]);
                usereducation.College = Convert.ToString(dr["College"]);

                usereducation.Status = Convert.ToString(dr["Status"]);

                usereducation.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                usereducation.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                usereducation.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                usereducation.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return usereducation;
        }


        public string AddUserEducation(UserEducation usereducation)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserEducation", con);
            //cmd.Parameters.Add("UserEducationId", SqlDbType.Int).Value = usereducation.UserEducationId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = usereducation.RegistrationId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = usereducation.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = usereducation.Description;
            cmd.Parameters.Add("University", SqlDbType.NVarChar).Value = usereducation.University;
            cmd.Parameters.Add("College", SqlDbType.NVarChar).Value = usereducation.College;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = usereducation.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = usereducation.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = usereducation.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = usereducation.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = usereducation.UpdatedDate;


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
        public string UpdateUserEducation(UserEducation usereducation)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserEducation", con);
            cmd.Parameters.Add("UserEducationId", SqlDbType.Int).Value = usereducation.UserEducationId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = usereducation.RegistrationId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = usereducation.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = usereducation.Description;
            cmd.Parameters.Add("University", SqlDbType.NVarChar).Value = usereducation.University;
            cmd.Parameters.Add("College", SqlDbType.NVarChar).Value = usereducation.College;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = usereducation.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = usereducation.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = usereducation.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = usereducation.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = usereducation.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return usereducation.UserEducationId.ToString();

        }

        /* public Loginc Loginc(string Email, string Password)
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


        public string DeleteUserEducation(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteUserEducation", con);
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