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
    public class AdminDetailDAL
    {
        DbConnection conn = null;
        public AdminDetailDAL()
        {
            conn = new DbConnection();
        }

        public List<AdminDetail> GetAllAdminDetail()
        {
            List<AdminDetail> admindetailList = new List<AdminDetail>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllAdminDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                AdminDetail admindetail = new AdminDetail();

                admindetail.AdminDetailId = Convert.ToInt32(dr["AdminDetailId"]);
                admindetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                admindetail.ProfileTagLine = Convert.ToString(dr["ProfileTagLine"]);
                admindetail.Photo = Convert.ToString(dr["Photo"]);
                admindetail.BirthDate = Convert.ToString(dr["BirthDate"]);
                admindetail.Address = Convert.ToString(dr["Address"]);

                admindetail.ContactNo = Convert.ToString(dr["ContactNo"]);

                admindetail.CountryId = Convert.ToInt32(dr["CountryId"]);
                admindetail.StateId = Convert.ToInt32(dr["StateId"]);
                admindetail.CityId = Convert.ToInt32(dr["CityId"]);

                admindetail.Status = Convert.ToString(dr["Status"]);
                admindetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                admindetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                admindetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                admindetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                admindetailList.Add(admindetail);
            }
            con.Close();
            return admindetailList;
        }


        /*public LoginCode GetLoginCodeByEmail(string Email)
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



        public AdminDetail GetAdminDetailById(int AdminDetailId)
        {
            AdminDetail admindetail = new AdminDetail();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAdminDetailById", con);
            cmd.Parameters.Add("AdminDetailId", SqlDbType.Int).Value = AdminDetailId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                admindetail.AdminDetailId = Convert.ToInt32(dr["AdminDetailId"]);
                admindetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                admindetail.ProfileTagLine = Convert.ToString(dr["ProfileTagLine"]);
                admindetail.Photo = Convert.ToString(dr["Photo"]);
                admindetail.BirthDate = Convert.ToString(dr["BirthDate"]);
                admindetail.Address = Convert.ToString(dr["Address"]);

                admindetail.ContactNo = Convert.ToString(dr["ContactNo"]);

                admindetail.CountryId = Convert.ToInt32(dr["CountryId"]);
                admindetail.StateId = Convert.ToInt32(dr["StateId"]);
                admindetail.CityId = Convert.ToInt32(dr["CityId"]);

                admindetail.Status = Convert.ToString(dr["Status"]);
                admindetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                admindetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                admindetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                admindetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return admindetail;
        }


        public string AddAdminDetail(AdminDetail admindetail)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddAdminDetail", con);
            //cmd.Parameters.Add("AdminDetailId", SqlDbType.Int).Value = admindetail.AdminDetailId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = admindetail.RegistrationId;
            cmd.Parameters.Add("ProfileTagLine", SqlDbType.NVarChar).Value = admindetail.ProfileTagLine;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = admindetail.Photo;
            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = admindetail.BirthDate;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = admindetail.Address;
            cmd.Parameters.Add("ContactNo", SqlDbType.NVarChar).Value = admindetail.ContactNo;
            cmd.Parameters.Add("CountryId", SqlDbType.Int).Value = admindetail.CountryId;
            cmd.Parameters.Add("StateId", SqlDbType.Int).Value = admindetail.StateId;
            cmd.Parameters.Add("CityId", SqlDbType.Int).Value = admindetail.CityId;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admindetail.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admindetail.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admindetail.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admindetail.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admindetail.UpdatedDate;


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
        public string UpdateAdminDetail(AdminDetail admindetail)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateAdminDetail", con);
            cmd.Parameters.Add("AdminDetailId", SqlDbType.Int).Value = admindetail.AdminDetailId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = admindetail.RegistrationId;
            cmd.Parameters.Add("ProfileTagLine", SqlDbType.NVarChar).Value = admindetail.ProfileTagLine;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = admindetail.Photo;
            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = admindetail.BirthDate;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = admindetail.Address;
            cmd.Parameters.Add("ContactNo", SqlDbType.NVarChar).Value = admindetail.ContactNo;
            cmd.Parameters.Add("CountryId", SqlDbType.Int).Value = admindetail.CountryId;
            cmd.Parameters.Add("StateId", SqlDbType.Int).Value = admindetail.StateId;
            cmd.Parameters.Add("CityId", SqlDbType.Int).Value = admindetail.CityId;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = admindetail.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = admindetail.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = admindetail.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = admindetail.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = admindetail.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return admindetail.AdminDetailId.ToString();

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


        public string DeleteAdminDetail(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteAdminDetail", con);
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
