using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class EmployerDAL
    {
        DbConnection conn = null;
        public EmployerDAL()
        {
            conn = new DbConnection();
        }


        public List<Employer> GetAllEmployer()

        {
            List<Employer> employerList = new List<Employer>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllEmployer", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Employer employer = new Employer();



                employer.EmployerId = Convert.ToInt32(dr["EmployerId"]);
                employer.VendorId = Convert.ToInt32(dr["VendorId"]);
               
                employer.CompanyName = Convert.ToString(dr["CompanyName"]);
                employer.Industry = Convert.ToString(dr["Industry"]);
                employer.Contact = Convert.ToString(dr["Contact"]);
                employer.Email = Convert.ToString(dr["Email"]);
                employer.Status = Convert.ToString(dr["Status"]);

                employer.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                employer.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                employer.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                employer.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                employerList.Add(employer);
            }
            con.Close();
            return employerList;
        }
        public string AddEmployer(Employer employer)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddEmployer", con);
            //cmd.Parameters.Add("EmployerId", SqlDbType.Int).Value = employer.EmployerId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = employer.VendorId;
           
            cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = employer.CompanyName;
            cmd.Parameters.Add("Industry", SqlDbType.NVarChar).Value = employer.Industry;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = employer.Contact;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = employer.Email;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = employer.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = employer.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = employer.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = employer.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = employer.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var EmployerId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return EmployerId.ToString();

        }

        [HttpPost]
        public string UpdateEmployer(Employer employer)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateEmployer", con);

            cmd.Parameters.Add("EmployerId", SqlDbType.Int).Value = employer.EmployerId;
            cmd.Parameters.Add("VendorId", SqlDbType.Int).Value = employer.VendorId;

            cmd.Parameters.Add("CompanyName", SqlDbType.NVarChar).Value = employer.CompanyName;
            cmd.Parameters.Add("Industry", SqlDbType.NVarChar).Value = employer.Industry;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = employer.Contact;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = employer.Email;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = employer.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = employer.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = employer.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = employer.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = employer.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var EmployerId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return employer.EmployerId.ToString();

        }

        public Employer GetEmployerById(int EmployerId)
        {
            Employer employer = new Employer();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetEmployerById", con);
            cmd.Parameters.Add("EmployerId", SqlDbType.Int).Value = EmployerId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                employer.EmployerId = Convert.ToInt32(dr["EmployerId"]);
                employer.VendorId = Convert.ToInt32(dr["VendorId"]);

                employer.CompanyName = Convert.ToString(dr["CompanyName"]);
                employer.Industry = Convert.ToString(dr["Industry"]);
                employer.Contact = Convert.ToString(dr["Contact"]);
                employer.Email = Convert.ToString(dr["Email"]);
                employer.Status = Convert.ToString(dr["Status"]);

                employer.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                employer.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                employer.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                employer.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return employer;
        }

        public string DeleteEmployer(int EmployerId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteEmployer", con);
            cmd.Parameters.Add("EmployerId", SqlDbType.Int).Value = EmployerId;
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