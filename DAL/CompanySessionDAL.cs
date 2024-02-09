using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;
namespace PrismAPI.DAL
{
    public class CompanySessionDAL
    {
        DbConnection conn = null;
        public CompanySessionDAL()
        {
            conn = new DbConnection();
        }


        public List<CompanySession> GetAllCompanySession()

        {
            List<CompanySession> CompanySessionList = new List<CompanySession>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllCompanySession", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CompanySession companySession = new CompanySession();
                //LoginCo loginCode = new LoginCo();


                companySession.CompanySessionId = Convert.ToInt32(dr["CompanySessionId"]);

                companySession.CompanyCourseId =  Convert.ToInt32(dr["CompanyCourseId"]);
                companySession.Title = Convert.ToString(dr["LName"]);
                companySession.SubTitle = Convert.ToString(dr["Email"]);
                companySession.Description = Convert.ToString(dr["Password"]);
                companySession.SessionDate = Convert.ToString(dr["EmailStatus"]);
                companySession.StartTime = Convert.ToString(dr["OTPNo"]);
                companySession.Link = Convert.ToString(dr["Link"]);
                companySession.Photo = Convert.ToString(dr["Photo"]);
                companySession.Status = Convert.ToString(dr["Status"]);

                companySession.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                companySession.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                companySession.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                companySession.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                CompanySessionList.Add(companySession);
            }
            con.Close();
            return CompanySessionList;
        }
        public string AddCompanySession(CompanySession companySession)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddCompanySession", con);
            //cmd.Parameters.Add("CompanySessionId", SqlDbType.Int).Value = companySession.CompanySessionId;
            cmd.Parameters.Add("CompanyCourseId", SqlDbType.Int).Value = companySession.CompanyCourseId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = companySession.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = companySession.SubTitle;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = companySession.Description;
            cmd.Parameters.Add("SessionDate", SqlDbType.NVarChar).Value = companySession.SessionDate;
            cmd.Parameters.Add("StartTime", SqlDbType.NVarChar).Value = companySession.StartTime;
            cmd.Parameters.Add("Link", SqlDbType.NVarChar).Value = companySession.Link;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = companySession.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = companySession.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companySession.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companySession.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companySession.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companySession.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var CompanySessionId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return CompanySessionId.ToString();

        }

        [HttpPost]
        public string UpdateCompanySession(CompanySession companySession)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateCompanySession", con);

            cmd.Parameters.Add("CompanySessionId", SqlDbType.Int).Value = companySession.CompanySessionId;
            cmd.Parameters.Add("CompanyCourseId", SqlDbType.Int).Value = companySession.CompanyCourseId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = companySession.Title;
            cmd.Parameters.Add("SubTitle", SqlDbType.NVarChar).Value = companySession.SubTitle;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = companySession.Description;
            cmd.Parameters.Add("SessionDate", SqlDbType.NVarChar).Value = companySession.SessionDate;
            cmd.Parameters.Add("StartTime", SqlDbType.NVarChar).Value = companySession.StartTime;
            cmd.Parameters.Add("Link", SqlDbType.NVarChar).Value = companySession.Link;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = companySession.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = companySession.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = companySession.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = companySession.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = companySession.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = companySession.UpdatedDate;



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var CompanySessionId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return companySession.CompanySessionId.ToString();

        }

        public CompanySession GetCompanySessionById(int CompanySessionId)
        {
            CompanySession companySession = new CompanySession();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetCompanySessionById", con);
            cmd.Parameters.Add("CompanySessionId", SqlDbType.Int).Value = CompanySessionId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                companySession.CompanySessionId = Convert.ToInt32(dr["CompanySessionId"]);

                companySession.CompanyCourseId =  Convert.ToInt32(dr["CompanyCourseId"]);
                companySession.Title = Convert.ToString(dr["LName"]);
                companySession.SubTitle = Convert.ToString(dr["Email"]);
                companySession.Description = Convert.ToString(dr["Password"]);
                companySession.SessionDate = Convert.ToString(dr["EmailStatus"]);
                companySession.StartTime = Convert.ToString(dr["OTPNo"]);
                companySession.Link = Convert.ToString(dr["Link"]);
                companySession.Photo = Convert.ToString(dr["Photo"]);
                companySession.Status = Convert.ToString(dr["Status"]);

                companySession.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                companySession.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                companySession.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                companySession.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return companySession;
        }
       
        public string DeleteCompanySession(int CompanySessionId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteCompanySession", con);
            cmd.Parameters.Add("CompanySessionId", SqlDbType.Int).Value = CompanySessionId;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "failed";
            }
            return "Success";
        }
       


    }
}