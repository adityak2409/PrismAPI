using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class EndUserPlanDAL
    {
        DbConnection conn = null;
        public EndUserPlanDAL()
        {
            conn = new DbConnection();
        }


        public List<EndUserPlan> GetAllEndUserPlan()

        {
            List<EndUserPlan> endUserPlanList = new List<EndUserPlan>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllEndUserPlan", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EndUserPlan endUserPlan = new EndUserPlan();
               


                endUserPlan.EndUserPlanId = Convert.ToInt32(dr["EndUserPlanId"]);

                endUserPlan.Title = Convert.ToString(dr["Title"]);
                endUserPlan.Description = Convert.ToString(dr["Description"]);
                endUserPlan.Price = Convert.ToString(dr["Price"]);
                endUserPlan.Photo = Convert.ToString(dr["Photo"]);
                endUserPlan.Status = Convert.ToString(dr["Status"]);


                endUserPlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                endUserPlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                endUserPlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                endUserPlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                endUserPlanList.Add(endUserPlan);
            }
            con.Close();
            return endUserPlanList;
        }
        public string AddEndUserPlan(EndUserPlan endUserPlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddEndUserPlan", con);
            //cmd.Parameters.Add("EndUserPlanId", SqlDbType.Int).Value = endUserPlan.EndUserPlanId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = endUserPlan.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = endUserPlan.Description;
            cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = endUserPlan.Price;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = endUserPlan.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = endUserPlan.Status;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = endUserPlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = endUserPlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = endUserPlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = endUserPlan.UpdatedDate;

            Random r = new Random();
            int num = r.Next();

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var EndUserPlanId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return EndUserPlanId.ToString();

        }

        [HttpPost]
        public string UpdateEndUserPlan(EndUserPlan endUserPlan)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateEndUserPlan", con);

            cmd.Parameters.Add("EndUserPlanId", SqlDbType.Int).Value = endUserPlan.EndUserPlanId;
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = endUserPlan.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = endUserPlan.Description;
            cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = endUserPlan.Price;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = endUserPlan.Photo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = endUserPlan.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = endUserPlan.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = endUserPlan.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = endUserPlan.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = endUserPlan.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var EndUserPlanId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return endUserPlan.EndUserPlanId.ToString();

        }

        public EndUserPlan GetEndUserPlanById(int EndUserPlanId)
        {
            EndUserPlan endUserPlan = new EndUserPlan();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetEndUserPlanById", con);
            cmd.Parameters.Add("EndUserPlanId", SqlDbType.Int).Value = EndUserPlanId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                endUserPlan.EndUserPlanId = Convert.ToInt32(dr["EndUserPlanId"]);

                endUserPlan.Title = Convert.ToString(dr["Title"]);
                endUserPlan.Description = Convert.ToString(dr["Description"]);
                endUserPlan.Price = Convert.ToString(dr["Price"]);
                endUserPlan.Photo = Convert.ToString(dr["Photo"]);
                endUserPlan.Status = Convert.ToString(dr["Status"]);


                endUserPlan.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                endUserPlan.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                endUserPlan.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                endUserPlan.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return endUserPlan;
        }

        public string DeleteEndUserPlan(int EndUserPlanId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteEndUserPlan", con);
            cmd.Parameters.Add("EndUserPlanId", SqlDbType.Int).Value = EndUserPlanId;
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