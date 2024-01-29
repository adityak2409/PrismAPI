using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Net.Http.Headers;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class EmployeeCodeDAL
    {
        DbConnection conn = null;
        public EmployeeCodeDAL()
        {
            conn = new DbConnection();
        }


        public List<EmployeeCode> GetAllEmployeeCode()
                
        {
            List<EmployeeCode> EmployeeCodeList = new List<EmployeeCode>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllEmployeeCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                EmployeeCode employeeCode = new EmployeeCode();
                employeeCode.BranchCode = new BranchCode();


                employeeCode.Id = Convert.ToInt32(dr["Id"]);
                
                employeeCode.EmpName = Convert.ToString(dr["EmpName"]);
                employeeCode.BirthDate = Convert.ToString(dr["BirthDate"]);
                employeeCode.Salary = Convert.ToString(dr["Salary"]);
                //employeeCode.BranchCode.Branch_Id = Convert.ToInt32(dr["BranchId"]);
                employeeCode.BranchCode.Branch_Name = Convert.ToString(dr["Branch_Name"]);

                employeeCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                employeeCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                employeeCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                employeeCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                EmployeeCodeList.Add(employeeCode);
            }
            con.Close();
            return EmployeeCodeList;
        }
        public string AddEmployeeCode(EmployeeCode employeeCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddEmployeeCode", con);
            //cmd.Parameters.Add("Id", SqlDbType.Int).Value = employeeCode.Id;


            cmd.Parameters.Add("EmpName", SqlDbType.NVarChar).Value = employeeCode.EmpName;
            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = employeeCode.BirthDate;
            cmd.Parameters.Add("Salary", SqlDbType.NVarChar).Value = employeeCode.Salary;
            //cmd.Parameters.Add("BranchId", SqlDbType.NVarChar).Value = employeeCode.BranchCode.Branch_Name;
            cmd.Parameters.Add("BranchId", SqlDbType.Int).Value = employeeCode.BranchCode.Branch_Id;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = employeeCode.Photo;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = employeeCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = employeeCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = employeeCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = employeeCode.UpdatedDate;

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
        public string UpdateEmployeeCode(EmployeeCode employeeCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateEmployeeCode", con);

            cmd.Parameters.Add("Id", SqlDbType.Int).Value = employeeCode.Id;
            cmd.Parameters.Add("EmpName", SqlDbType.NVarChar).Value = employeeCode.EmpName;
            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = employeeCode.BirthDate;
            cmd.Parameters.Add("Salary", SqlDbType.NVarChar).Value = employeeCode.Salary;
            //cmd.Parameters.Add("BranchId", SqlDbType.NVarChar).Value = employeeCode.BranchCode.Branch_Name;
            cmd.Parameters.Add("BranchId", SqlDbType.Int).Value = employeeCode.BranchCode.Branch_Id;
           
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = employeeCode.Photo;


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = employeeCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = employeeCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = employeeCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = employeeCode.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return employeeCode.Id.ToString();

        }

        public EmployeeCode GetEmployeeCodeById(int Id)
        {
            EmployeeCode employeeCode = new EmployeeCode();
            
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetEmployeeCodeById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                employeeCode.BranchCode = new BranchCode();
                employeeCode.Id = Convert.ToInt32(dr["Id"]);
                employeeCode.EmpName = Convert.ToString(dr["EmpName"]);
                employeeCode.BirthDate = Convert.ToString(dr["BirthDate"]);
                employeeCode.Salary = Convert.ToString(dr["Salary"]);
               
                employeeCode.BranchCode.Branch_Id = Convert.ToInt32(dr["BranchId"]);
                //employeeCode.BranchCode.Branch_Name = Convert.ToString(dr["BranchName"]);
                employeeCode.Photo = Convert.ToString(dr["Photo"]);


                employeeCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                employeeCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                employeeCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                employeeCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return employeeCode;
        }

        public string DeleteEmployeeCode(int id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteEmployeeCode", con);
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