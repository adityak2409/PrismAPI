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
    public class VendorRegistrationDAL
    {
        DbConnection conn = null;
        public VendorRegistrationDAL()
        {
            conn = new DbConnection();
        }

        public List<VendorRegistration> GetAllVendorRegistration()
        {
            List<VendorRegistration> vendorregistrationList = new List<VendorRegistration>();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetAllVendorRegistration", con);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();

            while (dr.Read())
            {
                VendorRegistration vendorregistration = new VendorRegistration();

                vendorregistration.VendorRegistrationId = Convert.ToInt32(dr["VendorRegistrationId"]);

                vendorregistration.FirstName = Convert.ToString(dr["FirstName"]);
                vendorregistration.LastName = Convert.ToString(dr["LastName"]);
                vendorregistration.Email = Convert.ToString(dr["Email"]);
                vendorregistration.Password = Convert.ToString(dr["Password"]);

                vendorregistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                vendorregistration.OtpNo = Convert.ToString(dr["OtpNo"]);

                vendorregistration.Status = Convert.ToString(dr["Status"]);

                vendorregistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendorregistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendorregistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendorregistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);

                vendorregistrationList.Add(vendorregistration);
            }
            con.Close();
            return vendorregistrationList;
        }


        /*  public AdminRegistration GetAdminRegistrationByEmail(string Email)
          {
              AdminRegistration loginCode = new AdminRegistration();

              SqlConnection con = conn.OpenDbConnection();
              SqlCommand cmd = new SqlCommand("GetAdminRegistrationByEmail", con);
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



        public VendorRegistration GetVendorRegistrationById(int VendorRegistrationId)
        {
            VendorRegistration vendorregistration = new VendorRegistration();

            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetVendorRegistrationById", con);
            cmd.Parameters.Add("VendorRegistrationId", SqlDbType.Int).Value = VendorRegistrationId;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                vendorregistration.VendorRegistrationId = Convert.ToInt32(dr["VendorRegistrationId"]);

                vendorregistration.FirstName = Convert.ToString(dr["FirstName"]);
                vendorregistration.LastName = Convert.ToString(dr["LastName"]);
                vendorregistration.Email = Convert.ToString(dr["Email"]);
                vendorregistration.Password = Convert.ToString(dr["Password"]);

                vendorregistration.EmailStatus = Convert.ToString(dr["EmailStatus"]);

                vendorregistration.OtpNo = Convert.ToString(dr["OtpNo"]);

                vendorregistration.Status = Convert.ToString(dr["Status"]);

                vendorregistration.CreatedBy = Convert.ToString(dr["CreatedBy"]);
                vendorregistration.CreatedDate = Convert.ToString(dr["CreatedDate"]);
                vendorregistration.UpdatedBy = Convert.ToString(dr["UpdatedBy"]);
                vendorregistration.UpdatedDate = Convert.ToString(dr["UpdatedDate"]);


            }
            con.Close();
            return vendorregistration;
        }


        public string AddVendorRegistration(VendorRegistration vendorregistration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("AddVendorRegistration", con);
            //cmd.Parameters.Add("VendorRegistrationId", SqlDbType.Int).Value = vendorregistration.VendorRegistrationId;

            cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = vendorregistration.FirstName;
            cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = vendorregistration.LastName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = vendorregistration.Email;

            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = vendorregistration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = vendorregistration.EmailStatus;

            cmd.Parameters.Add("OtpNo", SqlDbType.NVarChar).Value = vendorregistration.OtpNo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = vendorregistration.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendorregistration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendorregistration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendorregistration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendorregistration.UpdatedDate;


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
        public string UpdateVendorRegistration(VendorRegistration vendorregistration)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("UpdateVendorRegistration", con);
            cmd.Parameters.Add("VendorRegistrationId", SqlDbType.Int).Value = vendorregistration.VendorRegistrationId;

            cmd.Parameters.Add("FirstName", SqlDbType.NVarChar).Value = vendorregistration.FirstName;
            cmd.Parameters.Add("LastName", SqlDbType.NVarChar).Value = vendorregistration.LastName;
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = vendorregistration.Email;

            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = vendorregistration.Password;
            cmd.Parameters.Add("EmailStatus", SqlDbType.NVarChar).Value = vendorregistration.EmailStatus;

            cmd.Parameters.Add("OtpNo", SqlDbType.NVarChar).Value = vendorregistration.OtpNo;
            cmd.Parameters.Add("Status", SqlDbType.NVarChar).Value = vendorregistration.Status;
            cmd.Parameters.Add("CreatedBy", SqlDbType.NVarChar).Value = vendorregistration.CreatedBy;
            cmd.Parameters.Add("CreatedDate", SqlDbType.NVarChar).Value = vendorregistration.CreatedDate;
            cmd.Parameters.Add("UpdatedBy", SqlDbType.NVarChar).Value = vendorregistration.UpdatedBy;
            cmd.Parameters.Add("UpdatedDate", SqlDbType.NVarChar).Value = vendorregistration.UpdatedDate;


            cmd.CommandType = CommandType.StoredProcedure;
            object result = cmd.ExecuteScalar();

            var Id = result.ToString();
            con.Close();
            if (result.ToString() == "0")
            {
                return "Failed";
            }
            return vendorregistration.VendorRegistrationId.ToString();

        }

        public Loginv Loginv(string Email, string Password)
        {
            Loginv vendorregistration = new Loginv();
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("GetVendorRegistrationByEmailAndPassword", con);
            cmd.Parameters.Add("Email", SqlDbType.NVarChar).Value = Email;
            cmd.Parameters.Add("Password", SqlDbType.NVarChar).Value = Password;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                vendorregistration.VendorRegistrationId = Convert.ToInt32(dr["VendorRegistrationId"]);
                vendorregistration.Role = Convert.ToString(dr["Role"]);
            }
            return vendorregistration;
        }

        /*
                public OtpNo OtpNo(string Mobile)
                {
                    OtpNo OtpNo = new OtpNo();
                    SqlConnection con = conn.OpenDbConnection();
                    SqlCommand cmd = new SqlCommand("GetVendorRegistrationOtp", con);
                    cmd.Parameters.Add("Mobile", SqlDbType.NVarChar).Value = Mobile;

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        OtpNo.Id = Convert.ToInt32(dr["Id"]);
                        //vendorregistration.Role = Convert.ToString(dr["Role"]);
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


        public string DeleteVendorRegistration(int Id)
        {
            SqlConnection con = conn.OpenDbConnection();
            SqlCommand cmd = new SqlCommand("DeleteVendorRegistration", con);
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
