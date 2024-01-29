using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class BranchCodeDAL
    {
        DbConnection conn = null;
        public BranchCodeDAL()
        {
            conn = new DbConnection();
        }

        public List<BranchCode> GetAllBranchCode()
        {
            List<BranchCode> BranchCodeList = new List<BranchCode>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllBranchCode", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                BranchCode branchCode = new BranchCode();

                branchCode.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

                branchCode.Branch_Name = Convert.ToString(dr["Branch_Name"]);
                branchCode.Branch_Location = Convert.ToString(dr["Branch_Location"]);
              




                branchCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                branchCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                branchCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                branchCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                BranchCodeList.Add(branchCode);
            }
            con.Close();
            return BranchCodeList;
        }






        public BranchCode GetBranchCodeById(int Id)
        {
            BranchCode branchCode = new BranchCode();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetBranchCodeById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {




                branchCode.Branch_Id = Convert.ToInt32(dr["Branch_Id"]);

                branchCode.Branch_Name = Convert.ToString(dr["Branch_Name"]);
                branchCode.Branch_Location = Convert.ToString(dr["Branch_Location"]);





                branchCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                branchCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                branchCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                branchCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return branchCode;
        }


        public string AddBranchCode(BranchCode branchCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddBranchCode", con);
            //cmd.Parameters.Add("Branch_Id", SqlDbType.Int).Value = branchCode.Branch_Id;
            cmd.Parameters.Add("Branch_Name", SqlDbType.NVarChar).Value = branchCode.Branch_Name;
            cmd.Parameters.Add("Branch_Location", SqlDbType.NVarChar).Value = branchCode.Branch_Location;
            


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = branchCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value=branchCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = branchCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = branchCode.UpdatedDate;


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
        public string UpdateBranchCode(BranchCode branchCode)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateBranchCode", con);
            
            cmd.Parameters.Add("Branch_Id", SqlDbType.Int).Value = branchCode.Branch_Id;
            cmd.Parameters.Add("Branch_Name", SqlDbType.NVarChar).Value = branchCode.Branch_Name;
            cmd.Parameters.Add("Branch_Location", SqlDbType.NVarChar).Value = branchCode.Branch_Location;
            


            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = branchCode.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value=branchCode.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = branchCode.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = branchCode.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return branchCode.Branch_Id.ToString();

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


        public string DeleteBranchCode(int id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteBranchCode", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = id;
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