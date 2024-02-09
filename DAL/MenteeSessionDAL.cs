using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class MenteeSessionDAL
    {
        DbConnection conn = null;
        public MenteeSessionDAL()
        {
            conn = new DbConnection();
        }


        public List<MenteeSession> GetAllMenteeSession()

        {
            List<MenteeSession> menteeSessionList = new List<MenteeSession>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllMenteeSession", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                MenteeSession menteeSession = new MenteeSession();



                menteeSession.SessionId = Convert.ToInt32(dr["SessionId"]);
                menteeSession.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteeSession.Status = Convert.ToString(dr["Status"]);

                menteeSession.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteeSession.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteeSession.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteeSession.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                menteeSessionList.Add(menteeSession);
            }
            con.Close();
            return menteeSessionList;
        }
        public string AddMenteeSession(MenteeSession menteeSession)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddMenteeSession", con);
            //cmd.Parameters.Add("MenteeSessionId", SqlDbType.Int).Value = menteeSession.MenteeSessionId;
            cmd.Parameters.Add("SessionId", SqlDbType.Int).Value = menteeSession.SessionId;
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteeSession.MenteeProfileId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteeSession.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteeSession.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteeSession.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteeSession.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteeSession.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var MenteeSessionId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return MenteeSessionId.ToString();

        }

        [HttpPost]
        public string UpdateMenteeSession(MenteeSession menteeSession)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateMenteeSession", con);

            cmd.Parameters.Add("MenteeSessionId", SqlDbType.Int).Value = menteeSession.MenteeSessionId;
            cmd.Parameters.Add("SessionId", SqlDbType.Int).Value = menteeSession.SessionId;
            cmd.Parameters.Add("MenteeProfileId", SqlDbType.Int).Value = menteeSession.MenteeProfileId;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = menteeSession.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = menteeSession.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = menteeSession.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = menteeSession.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = menteeSession.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var MenteeSessionId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return menteeSession.MenteeSessionId.ToString();

        }

        public MenteeSession GetMenteeSessionById(int MenteeSessionId)
        {
            MenteeSession menteeSession = new MenteeSession();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetMenteeSessionById", con);
            cmd.Parameters.Add("MenteeSessionId", SqlDbType.Int).Value = MenteeSessionId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                menteeSession.MenteeSessionId = Convert.ToInt32(dr["MenteeSessionId"]);
                menteeSession.SessionId = Convert.ToInt32(dr["SessionId"]);
                menteeSession.MenteeProfileId = Convert.ToInt32(dr["MenteeProfileId"]);
                menteeSession.Status = Convert.ToString(dr["Status"]);

                menteeSession.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                menteeSession.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                menteeSession.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                menteeSession.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return menteeSession;
        }

        public string DeleteMenteeSession(int MenteeSessionId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteMenteeSession", con);
            cmd.Parameters.Add("MenteeSessionId", SqlDbType.Int).Value = MenteeSessionId;
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