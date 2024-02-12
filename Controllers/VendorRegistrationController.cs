using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using System.Web.Http.Cors;
using PrismAPI.DAL;
using PrismAPI.Models;


namespace PrismAPI.VendorRegistrationControllers
{
    public class VendorRegistrationController : ApiController
    {
        // GET: VendorRegistration
        public Logger Log = null;
        public VendorRegistrationController()
        {
            Log = Logger.GetLogger();
        }

        VendorRegistrationDAL vendorregistrationDAL = new VendorRegistrationDAL();

        [HttpGet]
        [ActionName("GetAllVendorRegistration")]
        public List<VendorRegistration> GetAllVendorRegistration()
        {
            Log.writeMessage("VendorRegistrationController GetAllVendorRegistration Start");
            List<VendorRegistration> list = null;
            try
            {
                list = vendorregistrationDAL.GetAllVendorRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorRegistrationController GetAllVendorRegistration Error " + ex.Message);
            }
            Log.writeMessage("VendorRegistrationController GetAllVendorRegistration End");
            return list;
        }

        [HttpGet]
        [ActionName("GetVendorRegistrationById")]
        public VendorRegistration GetVendorRegistrationById(int VendorRegistrationId)
        {
            Log.writeMessage("VendorRegistrationController GetVendorRegistrationById Start");
            VendorRegistration vendorregistration = null;
            try
            {
                vendorregistration = vendorregistrationDAL.GetVendorRegistrationById(VendorRegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorRegistrationController GetVendorRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("VendorRegistrationController GetVendorRegistrationById End");
            return vendorregistration;
        }

        /* [HttpGet]
         [ActionName("GetVendorRegistrationByEmail")]
         public VendorRegistration GetVendorRegistrationByEmail(string Email)
         {
             Log.writeMessage("VendorRegistrationController GetVendorRegistrationByEmail Start");
             VendorRegistration vendorregistration = null;
             try
             {
                 vendorregistration = vendorregistrationDAL.GetVendorRegistrationByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("VendorRegistrationController GetVendorRegistrationByEmail Error " + ex.Message);
             }
             Log.writeMessage("VendorRegistrationController GetVendorRegistrationByEmail End");
             return vendorregistration;
         }*/

        [HttpPost]
        [ActionName("AddVendorRegistration")]
        public IHttpActionResult AddVendorRegistration(VendorRegistration vendorregistration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                vendorregistration.CreatedBy = "Admin";
                vendorregistration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                vendorregistration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                vendorregistration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = vendorregistrationDAL.AddVendorRegistration(vendorregistration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorRegistrationController AddVendorRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateVendorRegistration")]
        public IHttpActionResult UpdateVendorRegistration(VendorRegistration vendorregistration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                vendorregistration.CreatedBy = "Admin";
                vendorregistration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                vendorregistration.UpdatedBy = "Admin";
                vendorregistration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = vendorregistrationDAL.UpdateVendorRegistration(vendorregistration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorRegistrationController AddVendorRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("Login")]
        public Loginv Loginv(string Email, string Password)
        {
            Log.writeMessage("VendorRegistrationController GetVendorRegistrationById Start");
            Loginv user = null;
            try
            {
                user = vendorregistrationDAL.Loginv(Email, Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorRegistrationController GetVendorRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("VendorRegistrationController GetVendorRegistrationById End");
            return user;
        }
        /*
                [HttpGet]
                [ActionName("OtpNo")]
                public OtpNo OtpNo(string Mobile)
                {
                    Log.writeMessage("VendorRegistrationController GetVendorRegistrationById Start");
                    OtpNo OtpNo = null;
                    try
                    {
                        OtpNo = vendorregistrationDAL.OtpNo(Mobile);
                    }
                    catch (Exception ex)
                    {
                        Log.writeMessage("VendorRegistrationController GetVendorRegistrationById Error " + ex.Message);
                    }
                    Log.writeMessage("VendorRegistrationController GetVendorRegistrationById End");
                    return OtpNo;
                }*/
        // PUT: api/Address/5
        //[HttpPut]
        //[ActionName("UpdateFirstModel")]
        //public IHttpActionResult UpdateFirstModel(FirstModel firstModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result = firstDAL.UpdateFirstModel(firstModel);




        //        if (result == "Success")
        //        {
        //            return Ok("Success");
        //        }
        //        else
        //        {
        //            return Ok("Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("FirstController UpdateFirstModel Error " + ex.Message);
        //    }
        //    return Ok("Failed");
        //}

        //// DELETE: api/Address/5

        public IHttpActionResult DeleteVendorRegistration(int Id)
        {
            try
            {
                var result = vendorregistrationDAL.DeleteVendorRegistration(Id);

                if (result == "Success")
                {
                    return Ok("Success");
                }
                else
                {
                    return Ok("Failed");
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage("VendorRegistrationController DeleteVendorRegistration Error " + ex.Message);
            }
            return Ok("Failed");
        }


        //[HttpPost]
        //public async Task<IActionResult> SendMail([FromBody] Email email)
        //{
        //    Console.WriteLine("Sending email");
        //    var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //    client.UseDefaultCredentials = false;
        //    client.EnableSsl = true;
        //    client.Credentials = new System.Net.NetworkCredential(emailid, password);
        //    var mailMessage = new System.Net.Mail.MailMessage();
        //    mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
        //    mailMessage.To.Add(email.To);
        //    mailMessage.Body = email.Text;
        //    await client.SendMailAsync(mailMessage);
        //    return Ok();
        //}


        //[HttpPost]
        //public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
        //{                  
        //    try
        //    {              
        //        if (!Request.Content.IsMimeMultipartContent())
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);
        //        foreach (var file in provider.Contents)
        //        {
        //            var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));

        //            File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
        //            //Do whatever you want with filename and its binary data.
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}

        //[HttpPost]
        //public void SaveProfilePhoto(UserProfilePhoto profile)
        //{
        //    try
        //    {
        //        byte[] imageBytes = Convert.FromBase64String(profile.Photo);
        //        string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //        string theDirectory = Path.GetDirectoryName(fullPath);
        //        theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //        //string filePath = "http://localhost:62842/ProfilePhoto/";
        //        File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "ProfilePicture_" + profile.Id + ".jpeg", imageBytes);
        //        //File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);

        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }
        //}


        /* [HttpPost]
         public async Task<IHttpActionResult> SaveVendorRegistrationImage(int Id)
         {
             try
             {
                 if (!Request.Content.IsMimeMultipartContent())
                     throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

                 var provider = new MultipartMemoryStreamProvider();
                 await Request.Content.ReadAsMultipartAsync(provider);
                 foreach (var file in provider.Contents)
                 {
                     var filename = file.Headers.ContentDisposition.FileName.Trim('\"');
                     var buffer = await file.ReadAsByteArrayAsync();
                     string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
                     //get the folder that's in
                     string theDirectory = Path.GetDirectoryName(fullPath);
                     theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
                     File.WriteAllBytes(theDirectory + "/Content/VendorRegistration" + "/" + Id + "_" + filename, buffer);
                     //Do whatever you want with filename and its binary data.

                     // get existing rocrd
                     var vendorregistration = vendorregistrationDAL.GetVendorRegistrationById(Id);
                     var filenamenew = Id + "_" + filename;
                     if (vendorregistration.Photo.ToLower() != filenamenew.ToLower())
                     {
                         File.Delete(theDirectory + "/Content/VendorRegistration" + "/" + vendorregistration.Photo);
                         vendorregistration.Photo = Id + "_" + filename;
                         var result = vendorregistrationDAL.UpdateVendorRegistration(vendorregistration);

                     }
                 }
             }
             catch (Exception ex)
             {
                 Log.writeMessage(ex.Message);
             }

             return Ok();*/
    }
}
