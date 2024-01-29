using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class SocialMediaDAL
    {
        DbConnection conn = null;
        public SocialMediaDAL()
        {
            conn = new DbConnection();
        }

        public List<SocialMedia> GetAllSocialMedia()
        {
            List<SocialMedia> SocialMediaList = new List<SocialMedia>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllSocialMedia ", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                SocialMedia  socialMedia  = new SocialMedia ();

                socialMedia .SocialMediaId = Convert.ToInt32(dr["SocialMediaId"]);
                socialMedia.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                socialMedia .Facebook = Convert.ToString(dr["Facebook"]);
                socialMedia .Instagram = Convert.ToString(dr["Instagram"]);
                socialMedia .LinkedIn = Convert.ToString(dr["LinkedIn"]);
                socialMedia .Twitter = Convert.ToString(dr["Twitter"]);
                socialMedia .Status = Convert.ToString(dr["Status"]);
               
                socialMedia .CreatedBy = Convert.ToString(dr["CreatedBy"]);
                socialMedia .CreatedDate = Convert.ToString(dr["CreatedDate"]);
                socialMedia .UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                socialMedia .UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                SocialMediaList.Add(socialMedia);
            }
            con.Close();
            return SocialMediaList;
        }






        public SocialMedia  GetSocialMediaById(int SocialMediaId)
        {
            SocialMedia  socialMedia  = new SocialMedia();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetSocialMediaById", con);
            cmd.Parameters.Add("SocialMediaId", SqlDbType.Int).Value = SocialMediaId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                socialMedia.SocialMediaId = Convert.ToInt32(dr["SocialMediaId"]);
                socialMedia.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                socialMedia.Facebook = Convert.ToString(dr["Facebook"]);
                socialMedia.Instagram = Convert.ToString(dr["Instagram"]);
                socialMedia.LinkedIn = Convert.ToString(dr["LinkedIn"]);
                socialMedia.Twitter = Convert.ToString(dr["Twitter"]);
                socialMedia.Status = Convert.ToString(dr["Status"]);

                socialMedia.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                socialMedia.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                socialMedia.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                socialMedia.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return socialMedia ;
        }


        public string AddSocialMedia (SocialMedia  socialMedia)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddSocialMedia ", con);
            //cmd.Parameters.Add("SocialMediaId", SqlDbType.Int).Value = socialMedia .SocialMediaId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = socialMedia.RegistrationId;
            cmd.Parameters.Add("Facebook", SqlDbType.NVarChar).Value = socialMedia .Facebook;
            cmd.Parameters.Add("Instagram", SqlDbType.NVarChar).Value = socialMedia .Instagram;
            cmd.Parameters.Add("LinkedIn", SqlDbType.NVarChar).Value = socialMedia .LinkedIn;
            cmd.Parameters.Add("Twitter", SqlDbType.NVarChar).Value = socialMedia .Twitter;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = socialMedia .Status;
          
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = socialMedia .CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = socialMedia .CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = socialMedia .UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = socialMedia .UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SocialMediaId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return SocialMediaId.ToString();

        }

        [HttpPost]
        public string UpdateSocialMedia (SocialMedia  socialMedia)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateSocialMedia", con);
            cmd.Parameters.Add("SocialMediaId", SqlDbType.Int).Value = socialMedia.SocialMediaId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = socialMedia.RegistrationId;
            cmd.Parameters.Add("Facebook", SqlDbType.NVarChar).Value = socialMedia.Facebook;
            cmd.Parameters.Add("Instagram", SqlDbType.NVarChar).Value = socialMedia.Instagram;
            cmd.Parameters.Add("LinkedIn", SqlDbType.NVarChar).Value = socialMedia.LinkedIn;
            cmd.Parameters.Add("Twitter", SqlDbType.NVarChar).Value = socialMedia.Twitter;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = socialMedia.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = socialMedia.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = socialMedia.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = socialMedia.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = socialMedia.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var SocialMediaId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return socialMedia.SocialMediaId.ToString();

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


        public string DeleteSocialMedia (int SocialMediaId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteSocialMedia ", con);
            cmd.Parameters.Add("SocialMediaId", SqlDbType.Int).Value = SocialMediaId;
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