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
using System.Web.UI.WebControls;

namespace PrismAPI.DAL
{
    public class AdminRegistrationDAL
    {
        DbConnection conn = null;
        public AdminRegistrationDAL()
        {
            conn = new DbConnection();
        }

        public List<AdminRegistration> GetAllAdminRegistration()
        {
            List<AdminRegistration> adminregistrationList = new List<AdminRegistration>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllAdminRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                AdminRegistration adminregistration = new AdminRegistration();

                adminregistration.AdminRegistrationId = Convert.ToInt32(dr["AdminRegistrationId"]);

                adminregistration.FirstName = Convert.ToString(dr["FirstName"]);
                adminregistration.LastName = Convert.ToString(dr["LastName"]);
                adminregistration.Email = Convert.ToString(dr["Email"]);
                adminregistration.Password = Convert.ToString(dr["Password"]);

                adminregistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                adminregistration.OtpNo = Convert.ToString(dr["OtpNo"]);

                adminregistration.Status = Convert.ToString(dr["Status"]);

                adminregistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                adminregistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                adminregistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                adminregistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                adminregistrationList.Add(adminregistration);
            }
            con.Close();
            return adminregistrationList;
        }


        public AdminRegistration GetAdminRegistrationByEmail(string Email)
        {
            AdminRegistration adminregistration = new AdminRegistration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdminRegistrationByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                adminregistration.AdminRegistrationId = Convert.ToInt32(dr["AdminRegistrationId"]);

                adminregistration.FirstName = Convert.ToString(dr["FirstName"]);
                adminregistration.LastName = Convert.ToString(dr["LastName"]);
                adminregistration.Email = Convert.ToString(dr["Email"]);
                adminregistration.Password = Convert.ToString(dr["Password"]);

                adminregistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                adminregistration.OtpNo = Convert.ToString(dr["OtpNo"]);

                adminregistration.Status = Convert.ToString(dr["Status"]);

                adminregistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                adminregistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                adminregistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                adminregistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return adminregistration;
        }



        public AdminRegistration GetAdminRegistrationById(int AdminRegistrationId)
        {
            AdminRegistration adminregistration = new AdminRegistration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdminRegistrationById", con);
            cmd.Parameters.Add("AdminRegistrationId", SqlDbType.Int).Value = AdminRegistrationId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                adminregistration.AdminRegistrationId = Convert.ToInt32(dr["AdminRegistrationId"]);

                adminregistration.FirstName = Convert.ToString(dr["FirstName"]);
                adminregistration.LastName = Convert.ToString(dr["LastName"]);
                adminregistration.Email = Convert.ToString(dr["Email"]);
                adminregistration.Password = Convert.ToString(dr["Password"]);

                adminregistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                adminregistration.OtpNo = Convert.ToString(dr["OtpNo"]);

                adminregistration.Status = Convert.ToString(dr["Status"]);

                adminregistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                adminregistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                adminregistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                adminregistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return adminregistration;
        }


        public string AddAdminRegistration(AdminRegistration adminregistration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddAdminRegistration", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = adminregistration.AdminRegistrationId;

            cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = adminregistration.FirstName;
            cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = adminregistration.LastName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = adminregistration.Email;

            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = adminregistration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = adminregistration.EmailStatus;

            cmd.Parameters.Add("OtpNo", SqlDbType.NVarChar).Value = adminregistration.OtpNo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = adminregistration.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = adminregistration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = adminregistration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = adminregistration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = adminregistration.UpdatedDate;


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
        public Logina Logina(string Email, string Password)
        {
            Logina adminregistration = new Logina();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdminRegistrationByEmailAndPassword", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                adminregistration.AdminRegistrationId = Convert.ToInt32(dr["AdminRegistrationId"]);
                //adminregistration.Role = Convert.ToString(dr["Role"]);
            }
            return adminregistration;
        }

        [HttpPost]
        public string UpdateAdminRegistration(AdminRegistration adminregistration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateAdminRegistration", con);
            cmd.Parameters.Add("AdminRegistrationId", SqlDbType.Int).Value = adminregistration.AdminRegistrationId;

            cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = adminregistration.FirstName;
            cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = adminregistration.LastName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = adminregistration.Email;

            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = adminregistration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = adminregistration.EmailStatus;

            cmd.Parameters.Add("OtpNo", SqlDbType.NVarChar).Value = adminregistration.OtpNo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = adminregistration.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = adminregistration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = adminregistration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = adminregistration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = adminregistration.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var AdminRegistrationId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return adminregistration.AdminRegistrationId.ToString();

        }
        /*
                public Loginac Loginac(string Email, string Password)
                {
                    Loginac user = new Loginac();
                    SqlConnection con = conn.OpenDbConnection();
                    SqlCommand cmd = new SqlCommand("GetAdminRegistrationEmailAndPassword", con);
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
                    SqlCommand cmd = new SqlCommand("GetAdminRegistrationOtp", con);
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


        public string DeleteAdminRegistration(int AdminRegistrationId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteAdminRegistration", con);
            cmd.Parameters.Add("AdminRegistrationId", SqlDbType.Int).Value = AdminRegistrationId;
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
