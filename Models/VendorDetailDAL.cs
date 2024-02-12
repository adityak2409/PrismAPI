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
    public class VendorDetailDAL
    {
        DbConnection conn = null;
        public VendorDetailDAL()
        {
            conn = new DbConnection();
        }

        public List<VendorDetail> GetAllVendorDetail()
        {
            List<VendorDetail> vendorDetailList = new List<VendorDetail>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllVendorDetail", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                VendorDetail vendordetail = new VendorDetail();

                vendordetail.VendorDetailId = Convert.ToInt32(dr["VendorDetailId"]);
                vendordetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                vendordetail.ProfileTagLine = Convert.ToString(dr["ProfileTagLine"]);
                vendordetail.Photo = Convert.ToString(dr["Photo"]);
                vendordetail.BirthDate = Convert.ToString(dr["BirthDate"]);
                vendordetail.Address = Convert.ToString(dr["Address"]);

                vendordetail.ContactNo = Convert.ToString(dr["ContactNo"]);

                vendordetail.CountryId = Convert.ToInt32(dr["CountryId"]);
                vendordetail.StateId = Convert.ToInt32(dr["StateId"]);
                vendordetail.CityId = Convert.ToInt32(dr["CityId"]);

                vendordetail.Status = Convert.ToString(dr["Status"]);
                vendordetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendordetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendordetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendordetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                vendorDetailList.Add(vendordetail);
            }
            con.Close();
            return vendorDetailList;
        }


        /*public LoginCode GetLoginCodeByEmail(string Email)
        {
            LoginCode loginCode = new LoginCode();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetUserLoginByEmail", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                loginCode.Id = Convert.ToInt32(dr["Id"]);

                loginCode.Name = Convert.ToString(dr["Name"]);
                loginCode.Email = Convert.ToString(dr["Email"]);
                loginCode.Mobile = Convert.ToString(dr["Mobile"]);
                loginCode.Password = Convert.ToString(dr["Password"]);
                loginCode.Address = Convert.ToString(dr["Address"]);

                loginCode.BirthDate = Convert.ToString(dr["BirthDate"]);

                loginCode.Photo = Convert.ToString(dr["Photo"]);
                loginCode.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                loginCode.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                loginCode.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                loginCode.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                loginCode.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);
            }
            con.Close();
            return loginCode;
        }*/



        public VendorDetail GetVendorDetailById(int VendorDetailId)
        {
            VendorDetail vendordetail = new VendorDetail();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetVendorDetailById", con);
            cmd.Parameters.Add("VendorDetailId", SqlDbType.Int).Value = VendorDetailId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                vendordetail.VendorDetailId = Convert.ToInt32(dr["VendorDetailId"]);
                vendordetail.RegistrationId = Convert.ToInt32(dr["RegistrationId"]);

                vendordetail.ProfileTagLine = Convert.ToString(dr["ProfileTagLine"]);
                vendordetail.Photo = Convert.ToString(dr["Photo"]);
                vendordetail.BirthDate = Convert.ToString(dr["BirthDate"]);
                vendordetail.Address = Convert.ToString(dr["Address"]);

                vendordetail.ContactNo = Convert.ToString(dr["ContactNo"]);

                vendordetail.CountryId = Convert.ToInt32(dr["CountryId"]);
                vendordetail.StateId = Convert.ToInt32(dr["StateId"]);
                vendordetail.CityId = Convert.ToInt32(dr["CityId"]);

                vendordetail.Status = Convert.ToString(dr["Status"]);
                vendordetail.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendordetail.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendordetail.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendordetail.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return vendordetail;
        }


        public string AddVendorDetail(VendorDetail vendordetail)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddVendorDetail", con);
            //cmd.Parameters.Add("VendorDetailId", SqlDbType.Int).Value = vendordetail.VendorDetailId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = vendordetail.RegistrationId;
            cmd.Parameters.Add("ProfileTagLine", SqlDbType.NVarChar).Value = vendordetail.ProfileTagLine;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = vendordetail.Photo;
            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = vendordetail.BirthDate;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = vendordetail.Address;
            cmd.Parameters.Add("ContactNo", SqlDbType.NVarChar).Value = vendordetail.ContactNo;
            cmd.Parameters.Add("CountryId", SqlDbType.Int).Value = vendordetail.CountryId;
            cmd.Parameters.Add("StateId", SqlDbType.Int).Value = vendordetail.StateId;
            cmd.Parameters.Add("CityId", SqlDbType.Int).Value = vendordetail.CityId;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = vendordetail.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendordetail.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendordetail.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendordetail.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendordetail.UpdatedDate;


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
        public string UpdateVendorDetail(VendorDetail vendordetail)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateVendorDetail", con);
            cmd.Parameters.Add("VendorDetailId", SqlDbType.Int).Value = vendordetail.VendorDetailId;
            cmd.Parameters.Add("RegistrationId", SqlDbType.Int).Value = vendordetail.RegistrationId;
            cmd.Parameters.Add("ProfileTagLine", SqlDbType.NVarChar).Value = vendordetail.ProfileTagLine;
            cmd.Parameters.Add("Photo", SqlDbType.NVarChar).Value = vendordetail.Photo;
            cmd.Parameters.Add("BirthDate", SqlDbType.NVarChar).Value = vendordetail.BirthDate;
            cmd.Parameters.Add("Address", SqlDbType.NVarChar).Value = vendordetail.Address;
            cmd.Parameters.Add("ContactNo", SqlDbType.NVarChar).Value = vendordetail.ContactNo;
            cmd.Parameters.Add("CountryId", SqlDbType.Int).Value = vendordetail.CountryId;
            cmd.Parameters.Add("StateId", SqlDbType.Int).Value = vendordetail.StateId;
            cmd.Parameters.Add("CityId", SqlDbType.Int).Value = vendordetail.CityId;

            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = vendordetail.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendordetail.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendordetail.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendordetail.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendordetail.UpdatedDate;

            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return vendordetail.VendorDetailId.ToString();

        }

        /* public Loginc Loginc(string Email, string Password)
         {
             Loginc user = new Loginc();
             SqlConnection con = conn.OpenDbConnection();
             SqlCommand cmd = new SqlCommand("GetUserEmailAndPassword", con);
             cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
             cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
             cmd.CommandType = CommandType.StoredProcedure;
             SqlDataReader dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 user.Id = Convert.ToInt32(dr["Id"]);
                 //user.Role = Convert.ToString(dr["Role"]);
             }
             return user;
         }


         public OtpNo OtpNo(string Mobile)
         {
             OtpNo OtpNo = new OtpNo();
             SqlConnection con = conn.OpenDbConnection();
             SqlCommand cmd = new SqlCommand("GetUserOtp", con);
             cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = Mobile;

             cmd.CommandType = CommandType.StoredProcedure;
             SqlDataReader dr = cmd.ExecuteReader();
             if (dr.Read())
             {
                 OtpNo.Id = Convert.ToInt32(dr["Id"]);
                 //user.Role = Convert.ToString(dr["Role"]);
             }
             return OtpNo;
         }*/
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


        public string DeleteVendorDetail(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteVendorDetail", con);
            cmd.Parameters.Add("Id", SqlDbType.Int).Value = Id;
            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return "Success";
        }
    }
}
