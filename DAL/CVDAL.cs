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
    public class CVDAL
    {
        DbConnection conn = null;
        public CVDAL()
        {
            conn = new DbConnection();
        }

        public List<CV> GetAllCV()
        {
            List<CV> cVList = new List<CV>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllCV", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CV cV = new CV();

                cV.CVId = Convert.ToInt32(dr["CVId"]);
                cV.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                cV.CVPDF = Convert.ToString(dr["CVPDF"]);
               
                cV.Status = Convert.ToString(dr["Status"]);
                cV.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                cV.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                cV.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                cV.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                cVList.Add(cV);
            }
            con.Close();
            return cVList;
        }


       



        public CV GetCVById(int CVId)
        {
            CV cV = new CV();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetCVById", con);
            cmd.Parameters.Add("CVId", SqlDbType.Int).Value = CVId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                cV.CVId = Convert.ToInt32(dr["CVId"]);
                cV.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                cV.CVPDF = Convert.ToString(dr["CVPDF"]);

                cV.Status = Convert.ToString(dr["Status"]);
                cV.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                cV.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                cV.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                cV.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return cV;
        }


        public string AddCV(CV cV)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddCV", con);
            //cmd.Parameters.Add("CVId", SqlDbType.Int).Value = cV.CVId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = cV.RegistrationId;
            cmd.Parameters.Add("CVPDF", SqlDbType.NVarChar).Value = cV.CVPDF;
            
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = cV.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = cV.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = cV.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = cV.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = cV.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var CVId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return CVId.ToString();

        }

        [HttpPost]
        public string UpdateCV(CV cV)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateCV", con);
            cmd.Parameters.Add("CVId", SqlDbType.Int).Value = cV.CVId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = cV.RegistrationId;
            cmd.Parameters.Add("CVPDF", SqlDbType.NVarChar).Value = cV.CVPDF;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = cV.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = cV.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = cV.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = cV.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = cV.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var CVId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return cV.CVId.ToString();

        }

       
        public string DeleteCV(int CVId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteCV", con);
            cmd.Parameters.Add("CVId", SqlDbType.Int).Value = CVId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
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
    }
}