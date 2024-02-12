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
using System.Net.Mail;



namespace PrismAPI.AdminRegistrationControllers
{
    public class AdminRegistrationController : ApiController
    {
        // GET: AdminRegistration
        public Logger Log = null;
        public AdminRegistrationController()
        {
            Log = Logger.GetLogger();
        }

        AdminRegistrationDAL adminregistrationDAL = new AdminRegistrationDAL();

        [HttpGet]

        [ActionName("GetAllAdminRegistration")]
        public List<AdminRegistration> GetAllAdminRegistration()
        {
            Log.writeMessage("AdminRegistrationController GetAllAdminRegistration Start");
            List<AdminRegistration> list = null;
            try
            {
                list = adminregistrationDAL.GetAllAdminRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminRegistrationController GetAllAdminRegistration Error " + ex.Message);
            }
            Log.writeMessage("AdminRegistrationController GetAllAdminRegistration End");
            return list;
        }

        [HttpGet]
        [ActionName("GetAdminRegistrationById")]
        public AdminRegistration GetAdminRegistrationById(int AdminRegistrationId)
        {
            Log.writeMessage("AdminRegistrationController GetAdminRegistrationById Start");
            AdminRegistration adminregistration = null;
            try
            {
                adminregistration = adminregistrationDAL.GetAdminRegistrationById(AdminRegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminRegistrationController GetAdminRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("AdminRegistrationController GetAdminRegistrationById End");
            return adminregistration;
        }

        [HttpGet]
        [ActionName("GetAdminRegistrationByEmail")]
        public AdminRegistration GetAdminRegistrationByEmail(string Email)
        {
            Log.writeMessage("AdminRegistrationController GetAdminRegistrationByEmail Start");
            AdminRegistration adminregistration = null;
            try
            {
                adminregistration = adminregistrationDAL.GetAdminRegistrationByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminRegistrationController GetAdminRegistrationByEmail Error " + ex.Message);
            }
            Log.writeMessage("AdminRegistrationController GetAdminRegistrationByEmail End");
            return adminregistration;
        }

        [HttpPost]
        [ActionName("AddAdminRegistration")]
        public IHttpActionResult AddAdminRegistration(AdminRegistration adminregistration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                adminregistration.CreatedBy = "Admin";
                adminregistration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                adminregistration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                adminregistration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = adminregistrationDAL.AddAdminRegistration(adminregistration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminRegistrationController AddAdminRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateAdminRegistration")]
        public IHttpActionResult UpdateAdminRegistration(AdminRegistration adminregistration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                adminregistration.CreatedBy = "Admin";
                adminregistration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                adminregistration.UpdatedBy = "Admin";
                adminregistration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = adminregistrationDAL.UpdateAdminRegistration(adminregistration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminRegistrationController AddAdminRegistration Error " + ex.Message);
            }
            return Ok(result);
        }


        [HttpGet]
        [ActionName("Logina")]
        public Logina Logina(string Email, string Password)
        {
            Log.writeMessage("AdminRegistrationController GetAdminRegistrationById Start");
            Logina adminregistration = null;
            try
            {
                adminregistration = adminregistrationDAL.Logina(Email, Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("AdminRegistrationController GetAdminRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("AdminRegistrationController GetAdminRegistrationById End");
            return adminregistration;
        }


        [HttpPost]
        [ActionName("SendOTPEmail")]
        public IHttpActionResult SendOTPEmail(string Email)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");

            try
            {
                // string fromEmail = "your-email@example.com"; // Replace with your email address
                //string fromEmailPassword = "your-password"; // Replace with your email password

                var smtpClient = new SmtpClient("smtp.gmail.com") // Replace with your SMTP server
                {
                    Port = 587, // Gmail uses port 587 for TLS
                    Credentials = new NetworkCredential("testsumit19@gmail.com", "dyld bnbm auks eopc"), // Replace with your Gmail email and password
                    EnableSsl = true,
                };


                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("testsumit19@gmail.com");
                mailMessage.To.Add(Email);
                mailMessage.Subject = "Your OTP Code";

                // Generate a 6-digit random OTP
                Random random = new Random();
                int otpValue = random.Next(100000, 999999);
                string otp = otpValue.ToString();

                mailMessage.Body = "Your OTP Code is: " + otp;

                smtpClient.Send(mailMessage);
                return Ok(new { otp });
            }
            catch (Exception ex)
            {
                // Handle any exceptions here
                Log.writeMessage("Error sending email: " + ex.Message);
                return BadRequest("Failed to send email: " + ex.Message);
            }
        }






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

        public IHttpActionResult DeleteAdminRegistration(int AdminRegistrationId)
        {
            try
            {
                var result = adminregistrationDAL.DeleteAdminRegistration(AdminRegistrationId);

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
                Log.writeMessage("AdminRegistrationController DeleteAdminRegistration Error " + ex.Message);
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
        //    var adminregistration = new System.Net.Mail.AdminRegistration();
        //    adminregistration.From = new System.Net.Mail.AdminRegistration(senderemail);
        //    adminregistration.To.Add(email.To);
        //    adminregistration.Body = email.Text;
        //    await client.SendMailAsync(adminregistration);
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
         public async Task<IHttpActionResult> SaveAdminRegistrationImage(int Id)
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
                     File.WriteAllBytes(theDirectory + "/Content/AdminRegistration" + "/" + Id + "_" + filename, buffer);
                     //Do whatever you want with filename and its binary data.

                     // get existing rocrd
                     var adminregistration = adminregistrationDAL.GetAdminRegistrationById(Id);
                     var filenamenew = Id + "_" + filename;
                     if (adminregistration.Photo.ToLower() != filenamenew.ToLower())
                     {
                         File.Delete(theDirectory + "/Content/AdminRegistration" + "/" + adminregistration.Photo);
                         adminregistration.Photo = Id + "_" + filename;
                         var result = adminregistrationDAL.UpdateAdminRegistration(adminregistration);

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
