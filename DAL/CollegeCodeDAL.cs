using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class CollegeCodeDAL
    {
        DbConnection conn = null;
        public CollegeCodeDAL()
        {
            conn = new DbConnection();
        }

        public List<CollegeCode> GetAllCollegeCode()
        {
            List<CollegeCode> CollegeCodeList = new List<CollegeCode>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllCollegeCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                CollegeCode collegeCode = new CollegeCode();

                collegeCode.Id = Convert.ToInt32(dr["Id"]);

                collegeCode.FName = Convert.ToString(dr["FName"]);
                collegeCode.LName = Convert.ToString(dr["LName"]);
                collegeCode.ContactNo = Convert.ToString(dr["ContactNo"]);
                collegeCode.Adress = Convert.ToString(dr["Adress"]);
                collegeCode.Email = Convert.ToString(dr["Email"]);
                collegeCode.Gender = Convert.ToString(dr["Gender"]);
                collegeCode.Photo = Convert.ToString(dr["Photo"]);



                collegeCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                collegeCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                collegeCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                collegeCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                CollegeCodeList.Add(collegeCode);
            }
            con.Close();
            return CollegeCodeList;
        }






        public CollegeCode GetCollegeCodeById(int Id)
        {
            CollegeCode collegeCode = new CollegeCode();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetCollegeCodeById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {


                

                collegeCode.Id = Convert.ToInt32(dr["Id"]);

                collegeCode.FName = Convert.ToString(dr["FName"]);
                collegeCode.LName = Convert.ToString(dr["LName"]);
                collegeCode.ContactNo = Convert.ToString(dr["ContactNo"]);
                collegeCode.Adress = Convert.ToString(dr["Adress"]);
                collegeCode.Email = Convert.ToString(dr["Email"]);
                collegeCode.Gender = Convert.ToString(dr["Gender"]);
                collegeCode.Photo = Convert.ToString(dr["Photo"]);



                collegeCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                collegeCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                collegeCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                collegeCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return collegeCode;
        }


        public string AddCollegeCode(CollegeCode collegeCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddCollegeCode", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = collegeCode.Id;
            cmd.Parameters.Add("FName", SqlDbType.NVarChar).Value = collegeCode.FName;
            cmd.Parameters.Add("LName", SqlDbType.NVarChar).Value = collegeCode.LName;
            cmd.Parameters.Add("ContactNo", SqlDbType.NVarChar).Value = collegeCode.ContactNo;
            cmd.Parameters.Add("Adress", SqlDbType.NVarChar).Value = collegeCode.Adress;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = collegeCode.Email;
            cmd.Parameters.Add("Gender", SqlDbType.NVarChar).Value = collegeCode.Gender;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = collegeCode.Photo;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = collegeCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = collegeCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = collegeCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = collegeCode.UpdatedDate;


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
        public string UpdateCollegeCode(CollegeCode collegeCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateCollegeCode", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = collegeCode.Id;

            cmd.Parameters.Add("FName", SqlDbType.NVarChar).Value = collegeCode.FName;
            cmd.Parameters.Add("LName", SqlDbType.NVarChar).Value = collegeCode.LName;
            cmd.Parameters.Add("ContactNo", SqlDbType.NVarChar).Value = collegeCode.ContactNo;
            cmd.Parameters.Add("Adress", SqlDbType.NVarChar).Value = collegeCode.Adress;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = collegeCode.Email;
            cmd.Parameters.Add("Gender", SqlDbType.NVarChar).Value = collegeCode.Gender;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = collegeCode.Photo;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = collegeCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = collegeCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = collegeCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = collegeCode.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return collegeCode.Id.ToString();

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


        public string DeleteCollegeCode(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteCollegeCode", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
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