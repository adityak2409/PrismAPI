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
    public class JobDAL
    {
        DbConnection conn = null;
        public JobDAL()
        {
            conn = new DbConnection();
        }

        public List<Job> GetAllJob()
        {
            List<Job> jobList = new List<Job>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllJob", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Job job = new Job();

                job.JobId = Convert.ToInt32(dr["JobId"]);
                job.EmployerId = Convert.ToInt32(dr["EmployerId"]);
               

                job.Title = Convert.ToString(dr["Title"]);
                job.JobType = Convert.ToString(dr["JobType"]);
                job.Description = Convert.ToString(dr["Description"]);
                job.Requirements = Convert.ToString(dr["Requirements"]);
                job.Location = Convert.ToString(dr["Location"]);
                job.Salary = Convert.ToString(dr["Salary"]);
                job.Status = Convert.ToString(dr["Status"]);
                job.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                job.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                job.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                job.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                jobList.Add(job);
            }
            con.Close();
            return jobList;
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



        public Job GetJobById(int JobId)
        {
            Job job = new Job();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetJobById", con);
            cmd.Parameters.Add("JobId", SqlDbType.Int).Value = JobId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {



                job.JobId = Convert.ToInt32(dr["JobId"]);
                job.EmployerId = Convert.ToInt32(dr["EmployerId"]);


                job.Title = Convert.ToString(dr["Title"]);
                job.JobType = Convert.ToString(dr["JobType"]);
                job.Description = Convert.ToString(dr["Description"]);
                job.Requirements = Convert.ToString(dr["Requirements"]);
                job.Location = Convert.ToString(dr["Location"]);
                job.Salary = Convert.ToString(dr["Salary"]);
                job.Status = Convert.ToString(dr["Status"]);
                job.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                job.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                job.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                job.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return job;
        }


        public string AddJob(Job job)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddJob", con);
            //cmd.Parameters.Add("JobId", SqlDbType.Int).Value = job.JobId;
            cmd.Parameters.Add("EmployerId", SqlDbType.Int).Value = job.EmployerId;
          
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = job.Title;
            cmd.Parameters.Add("JobType", SqlDbType.NVarChar).Value = job.JobType;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = job.Description;
            cmd.Parameters.Add("Requirements", SqlDbType.NVarChar).Value = job.Requirements;

            cmd.Parameters.Add("Location", SqlDbType.NVarChar).Value = job.Location;
            cmd.Parameters.Add("Salary", SqlDbType.NVarChar).Value = job.Salary;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = job.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = job.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = job.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = job.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = job.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var JobId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return JobId.ToString();

        }

        [HttpPost]
        public string UpdateJob(Job job)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateJob", con);
            cmd.Parameters.Add("JobId", SqlDbType.Int).Value = job.JobId;
            cmd.Parameters.Add("EmployerId", SqlDbType.Int).Value = job.EmployerId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = job.Title;
            cmd.Parameters.Add("JobType", SqlDbType.NVarChar).Value = job.JobType;
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = job.Description;
            cmd.Parameters.Add("Requirements", SqlDbType.NVarChar).Value = job.Requirements;

            cmd.Parameters.Add("Location", SqlDbType.NVarChar).Value = job.Location;
            cmd.Parameters.Add("Salary", SqlDbType.NVarChar).Value = job.Salary;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = job.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = job.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = job.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = job.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = job.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var JobId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return job.JobId.ToString();

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


        public string DeleteJob(int JobId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteJob", con);
            cmd.Parameters.Add("JobId", SqlDbType.Int).Value = JobId;
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