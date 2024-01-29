using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class IndustryDAL
    {
        DbConnection conn = null;
        public IndustryDAL()
        {
            conn = new DbConnection();
        }


        public List<Industry> GetAllIndustry()

        {
            List<Industry> industryList = new List<Industry>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllIndustry", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Industry industry = new Industry();

                industry.IndustryId = Convert.ToInt32(dr["IndustryId"]);
                industry.Title = Convert.ToString(dr["Title"]);
                industry.Description = Convert.ToString(dr["Description"]);
                industry.Status = Convert.ToString(dr["Status"]);


                industry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                industry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                industry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                industry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                industryList.Add(industry);
            }
            con.Close();
            return industryList;
        }
        public string AddIndustry(Industry industry)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddIndustry", con);
            //cmd.Parameters.Add("IndustryId", SqlDbType.Int).Value = industry.IndustryId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = industry.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = industry.Description;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = industry.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = industry.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = industry.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = industry.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = industry.UpdatedDate;

            Random r = new Random();
            int num = r.Next();

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var IndustryId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return IndustryId.ToString();

        }

        [HttpPost]
        public string UpdateIndustry(Industry industry)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateIndustry", con);

            cmd.Parameters.Add("IndustryId", SqlDbType.Int).Value = industry.IndustryId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = industry.Title;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = industry.Description;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = industry.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = industry.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = industry.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = industry.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = industry.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var IndustryId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return industry.IndustryId.ToString();

        }

        public Industry GetIndustryById(int IndustryId)
        {
            Industry industry = new Industry();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetIndustryById", con);
            cmd.Parameters.Add("IndustryId", SqlDbType.Int).Value = IndustryId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                industry.IndustryId = Convert.ToInt32(dr["IndustryId"]);
                industry.Title = Convert.ToString(dr["Title"]);
                industry.Description = Convert.ToString(dr["Description"]);
                industry.Status = Convert.ToString(dr["Status"]);


                industry.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                industry.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                industry.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                industry.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return industry;
        }

        public string DeleteIndustry(int IndustryId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteIndustry", con);
            cmd.Parameters.Add("IndustryId", SqlDbType.Int).Value = IndustryId;
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