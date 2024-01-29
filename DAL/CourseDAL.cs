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
    public class CourseDAL
    {
        DbConnection conn = null;
        public CourseDAL()
        {
            conn = new DbConnection();
        }

        public List<Course> GetAllCourse()
        {
            List<Course> courseList = new List<Course>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllCourse", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Course course = new Course();
                course.Instructor = new Instructor();


                course.CourseId = Convert.ToInt32(dr["CourseId"]);
                course.Instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);
                course.Instructor.Name = Convert.ToString(dr["Name"]);

                course.Title = Convert.ToString(dr["Title"]);

                course.Description = Convert.ToString(dr["Description"]);
                course.StartDate = Convert.ToString(dr["StartDate"]);
                course.EndDate = Convert.ToString(dr["EndDate"]);
                course.Price = Convert.ToString(dr["Price"]);
                course.Status = Convert.ToString(dr["Status"]);
                course.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                course.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                course.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                course.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                courseList.Add(course);
            }
            con.Close();
            return courseList;
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



        public Course GetCourseById(int CourseId)
        {
            Course course = new Course();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetCourseById", con);
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = CourseId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                course.Instructor = new Instructor();
                course.CourseId = Convert.ToInt32(dr["CourseId"]);
                course.Instructor.InstructorId = Convert.ToInt32(dr["InstructorId"]);


                course.Title = Convert.ToString(dr["Title"]);

                course.Description = Convert.ToString(dr["Description"]);
                course.StartDate = Convert.ToString(dr["StartDate"]);
                course.EndDate = Convert.ToString(dr["EndDate"]);
                course.Price = Convert.ToString(dr["Price"]);
                course.Status = Convert.ToString(dr["Status"]);
                course.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                course.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                course.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                course.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return course;
        }


        public string AddCourse(Course course)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddCourse", con);
            //cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = course.CourseId;
            cmd.Parameters.Add("InstructorId", SqlDbType.Int).Value = course.Instructor.InstructorId;
            
            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = course.Title;
           
            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = course.Description;
            cmd.Parameters.Add("StartDate", SqlDbType.NVarChar).Value = course.StartDate;
            cmd.Parameters.Add("EndDate", SqlDbType.NVarChar).Value = course.EndDate;
            cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = course.Price;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = course.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = course.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = course.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = course.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = course.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var CourseId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return CourseId.ToString();

        }

        [HttpPost]
        public string UpdateCourse(Course course)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateCourse", con);
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = course.CourseId;
            cmd.Parameters.Add("InstructorId", SqlDbType.Int).Value = course.Instructor.InstructorId;

            cmd.Parameters.Add("Title", SqlDbType.NVarChar).Value = course.Title;

            cmd.Parameters.Add("Description", SqlDbType.NVarChar).Value = course.Description;
            cmd.Parameters.Add("StartDate", SqlDbType.NVarChar).Value = course.StartDate;
            cmd.Parameters.Add("EndDate", SqlDbType.NVarChar).Value = course.EndDate;
            cmd.Parameters.Add("Price", SqlDbType.NVarChar).Value = course.Price;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = course.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = course.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = course.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = course.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = course.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var CourseId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return course.CourseId.ToString();

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


        public string DeleteCourse(int CourseId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteCourse", con);
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = CourseId;
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