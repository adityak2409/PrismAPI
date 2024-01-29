using PrismAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;

namespace PrismAPI.DAL
{
    public class ApplicantDAL
    {
        DbConnection conn = null;
        public ApplicantDAL()
        {
            conn = new DbConnection();
        }


        public List<Applicant> GetAllApplicant()

        {
            List<Applicant> applicantList = new List<Applicant>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllApplicant", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Applicant applicant = new Applicant();
                applicant.CV = new CV();

                applicant.ApplicantId = Convert.ToInt32(dr["ApplicantId"]);
                applicant.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                applicant.JobId = Convert.ToInt32(dr["JobId"]);
                applicant.CV.CVId = Convert.ToInt32(dr["CVId"]);
                applicant.CV.CVPDF = Convert.ToString(dr["CVPDF"]);

                applicant.Status = Convert.ToString(dr["Status"]);

                applicant.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                applicant.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                applicant.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                applicant.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                applicantList.Add(applicant);
            }
            con.Close();
            return applicantList;
        }
        public string AddApplicant(Applicant applicant)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddApplicant", con);
            //cmd.Parameters.Add("ApplicantId", SqlDbType.Int).Value = applicant.ApplicantId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = applicant.RegistrationId;
            cmd.Parameters.Add("JobId", SqlDbType.Int).Value = applicant.JobId;
            cmd.Parameters.Add("CVId", SqlDbType.Int).Value = applicant.CV.CVId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = applicant.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = applicant.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = applicant.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = applicant.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = applicant.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var ApplicantId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return ApplicantId.ToString();

        }

        [HttpPost]
        public string UpdateApplicant(Applicant applicant)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateApplicant", con);

            cmd.Parameters.Add("ApplicantId", SqlDbType.Int).Value = applicant.ApplicantId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = applicant.RegistrationId;
            cmd.Parameters.Add("JobId", SqlDbType.Int).Value = applicant.JobId;
            cmd.Parameters.Add("CVId", SqlDbType.Int).Value = applicant.CV.CVId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = applicant.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = applicant.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = applicant.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = applicant.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = applicant.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var ApplicantId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return applicant.ApplicantId.ToString();

        }

        public Applicant GetApplicantById(int ApplicantId)
        {
            Applicant applicant = new Applicant();
            applicant.CV=new CV();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetApplicantById", con);
            cmd.Parameters.Add("ApplicantId", SqlDbType.Int).Value = ApplicantId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                applicant.ApplicantId = Convert.ToInt32(dr["ApplicantId"]);
                applicant.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                applicant.JobId = Convert.ToInt32(dr["JobId"]);
                applicant.CV.CVId = Convert.ToInt32(dr["CVId"]);
                applicant.CV.CVPDF = Convert.ToString(dr["CVPDF"]);
                applicant.Status = Convert.ToString(dr["Status"]);

                applicant.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                applicant.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                applicant.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                applicant.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return applicant;
        }

        public string DeleteApplicant(int ApplicantId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteApplicant", con);
            cmd.Parameters.Add("ApplicantId", SqlDbType.Int).Value = ApplicantId;
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