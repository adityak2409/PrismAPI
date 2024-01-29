using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class StudentCodeDAL
    {

        DbConnection conn = null;
        public StudentCodeDAL()
        {
            conn = new DbConnection();
        }

        public List<StudentCode> GetAllStudentCode()
        {
            List<StudentCode> StudentCodeList = new List<StudentCode>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllStudentCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                StudentCode studentCode = new StudentCode();

                studentCode.Id = Convert.ToInt32(dr["Id"]);

                studentCode.SName = Convert.ToString(dr["SName"]);
                studentCode.SRollNo = Convert.ToInt32(dr["SRollNo"]);
                studentCode.CollegeId = Convert.ToInt32(dr["CollegeId"]);

                studentCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                studentCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                studentCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                studentCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                StudentCodeList.Add(studentCode);
            }
            con.Close();
            return StudentCodeList;
        }


        



        public StudentCode GetStudentCodeById(int Id)
        {
            StudentCode studentCode = new StudentCode();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserLoginById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                studentCode.Id = Convert.ToInt32(dr["Id"]);

                studentCode.SName = Convert.ToString(dr["SName"]);
                studentCode.SRollNo = Convert.ToInt32(dr["SRollNo"]);
                studentCode.CollegeId = Convert.ToInt32(dr["CollegeId"]);
               


                studentCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                studentCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                studentCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                studentCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return studentCode;
        }


        public string AddStudentCode(StudentCode studentCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddUserLogin", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = studentCode.Id;
            cmd.Parameters.Add("SName", SqlDbType.NVarChar).Value = studentCode.SName;
            cmd.Parameters.Add("SRollNo", SqlDbType.Int).Value = studentCode.SRollNo;
            cmd.Parameters.Add("CollegeId", SqlDbType.Int).Value = studentCode.CollegeId;
            
         
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = studentCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = studentCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = studentCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = studentCode.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return Id.ToString();

        }

        [HttpPost]
        public string UpdateStudentCode(StudentCode studentCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateUserLogin", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = studentCode.Id;

            cmd.Parameters.Add("SName", SqlDbType.NVarChar).Value = studentCode.SName;
            cmd.Parameters.Add("SRollNo", SqlDbType.NVarChar).Value = studentCode.SRollNo;
            cmd.Parameters.Add("CollegeId", SqlDbType.NVarChar).Value = studentCode.CollegeId;
           
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = studentCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = studentCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = studentCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = studentCode.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return studentCode.Id.ToString();

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


        public string DeleteStudentCode(int id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("deletefirstmodel", con);
            cmd.Parameters.Add("id", SqlDbType.Int).Value = id;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

             con.Close();
           if (result.ToString() == "0")
            {
               return "failed";
            }
            return "success";
        }
    }

}
