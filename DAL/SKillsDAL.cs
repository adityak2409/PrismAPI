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
    public class SKillsDAL
    {
        DbConnection conn = null;
        public SKillsDAL()
        {
            conn = new DbConnection();
        }

        public List<SKills> GetAllSKills()
        {
            List<SKills> sKillsList = new List<SKills>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllSKills", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SKills sKills = new SKills();



                sKills.SKillsId = Convert.ToInt32(dr["SKillsId"]);
                sKills.IndustryId = Convert.ToInt32(dr["IndustryId"]);
                sKills.Title = Convert.ToString(dr["Title"]);
                sKills.Description = Convert.ToString(dr["Description"]);
                sKills.CertificateStatus = Convert.ToString(dr["CertificateStatus"]);
                sKills.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                sKills.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                sKills.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                sKills.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                sKillsList.Add(sKills);
            }
            con.Close();
            return sKillsList;
        }


        //public LoginCode GetLoginCodeByEmail(string Email)
        //{
        //    LoginCode loginCode = new LoginCode();

        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserLoginByEmail", con);
        //    cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        loginCode.Id = Convert.ToInt32(dr["Id"]);

        //        loginCode.Name = Convert.ToString(dr["Name"]);
        //        loginCode.Email = Convert.ToString(dr["Email"]);
        //        loginCode.Mobile = Convert.ToString(dr["Mobile"]);
        //        loginCode.Password = Convert.ToString(dr["Password"]);
        //        loginCode.Address = Convert.ToString(dr["Address"]);

        //        loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

        //        loginCode.Photo = Convert.ToString(dr["Photo"]);
        //        loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

        //        loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
        //        loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
        //        loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
        //        loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
        //    }
        //    con.Close();
        //    return loginCode;
        //}



        public SKills GetSKillsById(int SKillsId)
        {
            SKills sKills = new SKills();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetSKillsById", con);
            cmd.Parameters.Add("SKillsId", SqlDbType.Int).Value = SKillsId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                sKills.SKillsId = Convert.ToInt32(dr["SKillsId"]);
                sKills.IndustryId = Convert.ToInt32(dr["IndustryId"]);
                sKills.Title = Convert.ToString(dr["Title"]);
                sKills.Description = Convert.ToString(dr["Description"]);
                sKills.CertificateStatus = Convert.ToString(dr["CertificateStatus"]);
                sKills.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                sKills.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                sKills.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                sKills.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return sKills;
        }


        public string AddSKills(SKills sKills)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddSKills", con);
            //cmd.Parameters.Add("SKillsId", SqlDbType.Int).Value = sKills.SKillsId;
            cmd.Parameters.Add("IndustryId", SqlDbType.Int).Value = sKills.IndustryId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = sKills.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = sKills.Description;
            cmd.Parameters.Add("CertificateStatus", SqlDbType.NVarChar).Value = sKills.CertificateStatus;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = sKills.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = sKills.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = sKills.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = sKills.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SKillsId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return SKillsId.ToString();

        }

        [HttpPost]
        public string UpdateSKills(SKills sKills)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateSKills", con);
            cmd.Parameters.Add("SKillsId", SqlDbType.Int).Value = sKills.SKillsId;
            cmd.Parameters.Add("IndustryId", SqlDbType.Int).Value = sKills.IndustryId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = sKills.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = sKills.Description;
            cmd.Parameters.Add("CertificateStatus", SqlDbType.NVarChar).Value = sKills.CertificateStatus;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = sKills.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = sKills.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = sKills.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = sKills.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SKillsId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return sKills.SKillsId.ToString();

        }

        //public Loginc Loginc(string Email, string Password)
        //{
        //    Loginc user = new Loginc();
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserEmailAndPassword", con);
        //    cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
        //    cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        // user.Id = Convert.ToInt32(dr["Id"]);
        //        //user.Role = Convert.ToString(dr["Role"]);
        //    }
        //    return user;
        //}


        //public OtpNo OtpNo(string Mobile)
        //{
        //    OtpNo OtpNo = new OtpNo();
        //    SqlConnection con = conn.OpenDbConnection();
        //    SqlCommand cmd = new SqlCommand("GetUserOtp", con);
        //    cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = Mobile;

        //    cmd.CommandType = CommandType.StoredProcedure;
        //    SqlDataReader dr = cmd.ExecuteReader();
        //    if (dr.Read())
        //    {
        //        OtpNo.Id = Convert.ToInt32(dr["Id"]);
        //        //user.Role = Convert.ToString(dr["Role"]);
        //    }
        //    return OtpNo;
        //}
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


        public string DeleteSKills(int SKillsId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteSKills", con);
            cmd.Parameters.Add("SKillsId", SqlDbType.Int).Value = SKillsId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
            //}
        }
    }
}
