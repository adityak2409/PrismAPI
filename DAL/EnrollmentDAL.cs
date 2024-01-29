using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class EnrollmentDAL
    {
        DbConnection conn = null;
        public EnrollmentDAL()
        {
            conn = new DbConnection();
        }

        public List<Enrollment> GetAllEnrollment()
        {
            List<Enrollment> enrollmentList = new List<Enrollment>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllEnrollment", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Enrollment enrollment = new Enrollment();

                enrollment.EnrollmentId = Convert.ToInt32(dr["EnrollmentId"]);
                enrollment.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                enrollment.CourseId = Convert.ToInt32(dr["CourseId"]);
               
                enrollment.Status = Convert.ToString(dr["Status"]);

                enrollment.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                enrollment.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                enrollment.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                enrollment.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                enrollmentList.Add(enrollment);
            }
            con.Close();
            return enrollmentList;
        }


        public Enrollment GetEnrollmentById(int EnrollmentId)
        {
            Enrollment enrollment = new Enrollment();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetEnrollmentById", con);
            cmd.Parameters.Add("EnrollmentId", SqlDbType.Int).Value = EnrollmentId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                enrollment.EnrollmentId = Convert.ToInt32(dr["EnrollmentId"]);
                enrollment.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                enrollment.CourseId = Convert.ToInt32(dr["CourseId"]);

                enrollment.Status = Convert.ToString(dr["Status"]);

                enrollment.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                enrollment.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                enrollment.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                enrollment.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return enrollment;
        }


        public string AddEnrollment(Enrollment enrollment)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddEnrollment", con);
            //cmd.Parameters.Add("EnrollmentId", SqlDbType.Int).Value = enrollment.EnrollmentId;

            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = enrollment.RegistrationId;
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = enrollment.CourseId;
       
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = enrollment.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = enrollment.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = enrollment.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = enrollment.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = enrollment.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var EnrollmentId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return EnrollmentId.ToString();

        }

        [HttpPost]
        public string UpdateEnrollment(Enrollment enrollment)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateEnrollment", con);
            cmd.Parameters.Add("EnrollmentId", SqlDbType.Int).Value = enrollment.EnrollmentId;

            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = enrollment.RegistrationId;
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = enrollment.CourseId;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = enrollment.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = enrollment.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = enrollment.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = enrollment.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = enrollment.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var EnrollmentId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return enrollment.EnrollmentId.ToString();

        }


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


        public string DeleteEnrollment(int EnrollmentId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteEnrollment", con);
            cmd.Parameters.Add("EnrollmentId", SqlDbType.Int).Value = EnrollmentId;
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