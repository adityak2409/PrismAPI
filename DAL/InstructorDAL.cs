using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class InstructorDAL
    {
        DbConnection conn = null;
        public InstructorDAL()
        {
            conn = new DbConnection();
        }


        public List<Instructor> GetAllInstructor()

       {
            List<Instructor> instructorList = new List<Instructor>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllInstructor", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Instructor instructor = new Instructor();



                instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                instructor.Name = Convert.ToString(dr["Name"]);
                instructor.Bio = Convert.ToString(dr["Bio"]);
                instructor.Email = Convert.ToString(dr["Email"]);
                instructor.Contact = Convert.ToString(dr["Contact"]);
                
                instructor.Status = Convert.ToString(dr["Status"]);

                instructor.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                instructor.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                instructor.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                instructor.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                instructorList.Add(instructor);
            }
            con.Close();
            return instructorList;
        }
        public string AddInstructor(Instructor instructor)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddInstructor", con);
            //  instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);
           

            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = instructor.Name;
            cmd.Parameters.Add("Bio", SqlDbType.NVarChar).Value = instructor.Bio;

            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = instructor.Email;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = instructor.Contact;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = instructor.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = instructor.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = instructor.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = instructor.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = instructor.UpdatedDate;

            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var InstructorId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return InstructorId.ToString();

        }

        [HttpPost]
        public string UpdateInstructor(Instructor instructor)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateInstructor", con);

            cmd.Parameters.Add("InstructorId", SqlDbType.Int).Value = instructor.InstructorId;
          
            cmd.Parameters.Add("Name", SqlDbType.NVarChar).Value = instructor.Name;
            cmd.Parameters.Add("Bio", SqlDbType.NVarChar).Value = instructor.Bio;
            
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = instructor.Email;
            cmd.Parameters.Add("Contact", SqlDbType.NVarChar).Value = instructor.Contact;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = instructor.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = instructor.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = instructor.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = instructor.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = instructor.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var InstructorId = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return instructor.InstructorId.ToString();

        }

        public Instructor GetInstructorById(int InstructorId)
        {
            Instructor instructor = new Instructor();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetInstructorById", con);
            cmd.Parameters.Add("InstructorId", SqlDbType.Int).Value = InstructorId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                instructor.Name = Convert.ToString(dr["Name"]);
                instructor.Bio = Convert.ToString(dr["Bio"]);
                instructor.Email = Convert.ToString(dr["Email"]);
                instructor.Contact = Convert.ToString(dr["Contact"]);

                instructor.Status = Convert.ToString(dr["Status"]);

                instructor.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                instructor.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                instructor.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                instructor.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return instructor;
        }

        public string DeleteInstructor(int InstructorId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteInstructor", con);
            cmd.Parameters.Add("InstructorId", SqlDbType.Int).Value = InstructorId;
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