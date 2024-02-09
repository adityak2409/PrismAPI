using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class UserSkillDAL
    {
        DbConnection conn = null;
        public UserSkillDAL()
        {
            conn = new DbConnection();
        }

        public List<UserSkill> GetAllUserSkill()
        {
            List<UserSkill> UserSkillList = new List<UserSkill>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllUserSkill", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                UserSkill userSkill = new UserSkill();

                userSkill.UserSkillId = Convert.ToInt32(dr["UserSkillId"]);
                userSkill.CompanyUserId = Convert.ToInt32(dr["CompanyUserId"]);
                userSkill.SkillId = Convert.ToInt32(dr["SkillId"]);
                userSkill.Certificate = Convert.ToString(dr["Certificate"]);
              
                userSkill.Status = Convert.ToString(dr["Status"]);

                userSkill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                userSkill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                userSkill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                userSkill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                UserSkillList.Add(userSkill);
            }
            con.Close();
            return UserSkillList;
        }


        public UserSkill GetUserSkillById(int Id)
        {
            UserSkill userSkill = new UserSkill();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserSkillById", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                userSkill.UserSkillId = Convert.ToInt32(dr["UserSkillId"]);
                userSkill.CompanyUserId = Convert.ToInt32(dr["CompanyUserId"]);
                userSkill.SkillId = Convert.ToInt32(dr["SkillId"]);
                userSkill.Certificate = Convert.ToString(dr["Certificate"]);

                userSkill.Status = Convert.ToString(dr["Status"]);

                userSkill.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                userSkill.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                userSkill.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                userSkill.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

            }
            con.Close();
            return userSkill;
        }


        public string AddUserSkill(UserSkill userSkill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AdduserSkill", con);
            //cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = userSkill.UserSkillId;
            cmd.Parameters.Add("CompanyUserId", SqlDbType.Int).Value = userSkill.CompanyUserId;
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = userSkill.SkillId;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = userSkill.Certificate;
           
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userSkill.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userSkill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userSkill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userSkill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userSkill.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var UserSkillId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return UserSkillId.ToString();

        }

        [HttpPost]
        public string UpdateUserSkill(UserSkill userSkill)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateCollegeCode", con);
            cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = userSkill.UserSkillId;
            cmd.Parameters.Add("CompanyUserId", SqlDbType.Int).Value = userSkill.CompanyUserId;
            cmd.Parameters.Add("SkillId", SqlDbType.Int).Value = userSkill.SkillId;
            cmd.Parameters.Add("Certificate", SqlDbType.NVarChar).Value = userSkill.Certificate;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = userSkill.Status;



            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = userSkill.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = userSkill.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = userSkill.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = userSkill.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var UserSkillId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return userSkill.UserSkillId.ToString();

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


        public string DeleteUserSkill(int UserSkillId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteCollegeCode", con);
            cmd.Parameters.Add("UserSkillId", SqlDbType.Int).Value = UserSkillId;
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