using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
using PrismAPI.Models;

namespace PrismAPI.DAL
{
    public class ReviewsDAL
    {
        DbConnection conn = null;
        public ReviewsDAL()
        {
            conn = new DbConnection();
        }

        public List<Reviews> GetAllReviews()
        {
            List<Reviews> ReviewsList = new List<Reviews>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllReviews", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                Reviews reviews = new Reviews();

                reviews.ReviewsId = Convert.ToInt32(dr["ReviewsId"]);
                reviews.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                reviews.CourseId = Convert.ToInt32(dr["CourseId"]);
                reviews.Rating = Convert.ToString(dr["Rating"]);
                reviews.Comment = Convert.ToString(dr["Comment"]);
                reviews.Status = Convert.ToString(dr["Status"]);
                
                reviews.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                reviews.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                reviews.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                reviews.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                ReviewsList.Add(reviews);
            }
            con.Close();
            return ReviewsList;
        }


        public Reviews GetReviewsById(int ReviewsId)
        {
            Reviews reviews = new Reviews();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetReviewsById", con);
            cmd.Parameters.Add("ReviewsId", SqlDbType.Int).Value = ReviewsId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                reviews.ReviewsId = Convert.ToInt32(dr["ReviewsId"]);
                reviews.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);
                reviews.CourseId = Convert.ToInt32(dr["CourseId"]);
                reviews.Rating = Convert.ToString(dr["Rating"]);
                reviews.Comment = Convert.ToString(dr["Comment"]);
                reviews.Status = Convert.ToString(dr["Status"]);

                reviews.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                reviews.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                reviews.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                reviews.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return reviews;
        }


        public string AddReviews(Reviews reviews)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddReviews", con);
            //cmd.Parameters.Add("ReviewsId", SqlDbType.Int).Value = reviews.ReviewsId;
            
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = reviews.RegistrationId;
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = reviews.CourseId;
            cmd.Parameters.Add("Rating", SqlDbType.NVarChar).Value = reviews.Rating;
            cmd.Parameters.Add("Comment", SqlDbType.NVarChar).Value = reviews.Comment;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = reviews.Status;
            
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = reviews.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = reviews.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = reviews.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = reviews.UpdatedDate;


            Random r = new Random();
            int num = r.Next();



            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var ReviewsId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return ReviewsId.ToString();

        }

        [HttpPost]
        public string UpdateReviews(Reviews reviews)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateReviews", con);
            cmd.Parameters.Add("ReviewsId", SqlDbType.Int).Value = reviews.ReviewsId;

            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = reviews.RegistrationId;
            cmd.Parameters.Add("CourseId", SqlDbType.Int).Value = reviews.CourseId;
            cmd.Parameters.Add("Rating", SqlDbType.NVarChar).Value = reviews.Rating;
            cmd.Parameters.Add("Comment", SqlDbType.NVarChar).Value = reviews.Comment;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = reviews.Status;

            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = reviews.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = reviews.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = reviews.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = reviews.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var ReviewsId = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return reviews.ReviewsId.ToString();

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


        public string DeleteReviews(int ReviewsId)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteReviews", con);
            cmd.Parameters.Add("ReviewsId", SqlDbType.Int).Value = ReviewsId;
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