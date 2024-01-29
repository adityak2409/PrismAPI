using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class ApplicationTrackerDAL
    {
        DbConnection conn = null;
        public ApplicationTrackerDAL()
        {
            conn = new DbConnection();
        }


        public List<ApplicationTracker> GetAllApplicationTracker()

        {
            List<ApplicationTracker> applicationTrackerList = new List<ApplicationTracker>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllApplicationTracker", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                ApplicationTracker applicationTracker = new ApplicationTracker();



                applicationTracker.ApplicationTrackerId = Convert.ToInt32(dr["ApplicationTrackerId"]);
                applicationTracker.ApplicantId = Convert.ToInt32(dr["ApplicantId"]);
                applicationTracker.Status = Convert.ToString(dr["Status"]);

                applicationTracker.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                applicationTracker.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                applicationTracker.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                applicationTracker.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                applicationTrackerList.Add(applicationTracker);
            }
            con.Close();
            return applicationTrackerList;
        }
        public string AddApplicationTracker(ApplicationTracker applicationTracker)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddApplicationTracker", con);
            //cmd.Parameters.Add("ApplicationTrackerId", SqlDbType.Int).Value = applicationTracker.ApplicationTrackerId;
            cmd.Parameters.Add("ApplicantId", SqlDbType.Int).Value = applicationTracker.ApplicantId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = applicationTracker.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = applicationTracker.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = applicationTracker.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = applicationTracker.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = applicationTracker.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var ApplicationTrackerId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return ApplicationTrackerId.ToString();

        }

        [HttpPost]
        public string UpdateApplicationTracker(ApplicationTracker applicationTracker)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateApplicationTracker", con);

            cmd.Parameters.Add("ApplicationTrackerId", SqlDbType.Int).Value = applicationTracker.ApplicationTrackerId;
            cmd.Parameters.Add("ApplicantId", SqlDbType.Int).Value = applicationTracker.ApplicantId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = applicationTracker.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = applicationTracker.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = applicationTracker.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = applicationTracker.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = applicationTracker.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var ApplicationTrackerId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return applicationTracker.ApplicationTrackerId.ToString();

        }

        public ApplicationTracker GetApplicationTrackerById(int ApplicationTrackerId)
        {
            ApplicationTracker applicationTracker = new ApplicationTracker();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetApplicationTrackerById", con);
            cmd.Parameters.Add("ApplicationTrackerId", SqlDbType.Int).Value = ApplicationTrackerId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                applicationTracker.ApplicationTrackerId = Convert.ToInt32(dr["ApplicationTrackerId"]);
                applicationTracker.ApplicantId = Convert.ToInt32(dr["ApplicantId"]);
                applicationTracker.Status = Convert.ToString(dr["Status"]);

                applicationTracker.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                applicationTracker.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                applicationTracker.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                applicationTracker.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return applicationTracker;
        }

        public string DeleteApplicationTracker(int ApplicationTrackerId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteApplicationTracker", con);
            cmd.Parameters.Add("ApplicationTrackerId", SqlDbType.Int).Value = ApplicationTrackerId;
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