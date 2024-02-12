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

namespace PrismAPI.Controllers
{
    public class RegistrationController : ApiController
    {
        public Logger Log = null;
        public RegistrationController()
        {
            Log = Logger.GetLogger();
        }
        RegistrationDAL registrationDAL = new RegistrationDAL();

        [HttpGet]
        [ActionName("GetAllRegistration")]

        public List<Registration> GetAllRegistration()
        {
            Log.writeMessage("RegistrationController GetAllRegistration Start");
            List<Registration> list = null;
            try
            {
                list = registrationDAL.GetAllRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetAllRegistration Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetAllRegistration End");
            return list;

        }

        [HttpPost]
        [ActionName("AddRegistration")]
        public IHttpActionResult AddRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                registration.CreatedBy = "Admin";
                registration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                registration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = registrationDAL.AddRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateRegistration")]
        public IHttpActionResult UpdateRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                registration.CreatedBy = "Admin";
                registration.UpdatedBy = "Admin";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = registrationDAL.UpdateRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetRegistrationById")]
        public Registration GetRegistrationById(int RegistrationId)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationById(RegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return registration;
        }
        public IHttpActionResult DeleteRegistration(int RegistrationId)
        {
            try
            {
                var result = registrationDAL.DeleteRegistration(RegistrationId);

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
                Log.writeMessage("RegistrationController DeleteRegistration Error " + ex.Message);
            }
            return Ok("Failed");
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


        [HttpGet]
        [ActionName("GetRegistrationByEmail")]
        public Registration GetRegistrationByEmail(string Email)
        {
            Log.writeMessage("RegistrationController GetRegistrationByEmail Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationByEmail(Email);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationByEmail Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationByEmail End");
            return registration;
        }


        [HttpGet]
        [ActionName("Login")]
        public LoginCo Login(string Email, string Password)
        {
            Log.writeMessage("RegistrationController Login Start");
            LoginCo user = null;
            try
            {
                user = registrationDAL.Login(Email,Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return user;
        }






        //[HttpPost]
        //public async Task<IHttpActionResult> SaveRegistrationImage(int RegistrationId)
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
        //            //var filename1 = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //            File.WriteAllBytes(theDirectory + "/Content/Registration" + "/" + RegistrationId + "_" + filename, buffer);
        //            //File.WriteAllBytes(theDirectory + "/Content/Registration" + "/" + RegistrationId + "_" + filename1, buffer);
        //            //Do whatever you want with filename and its binary data.

        //            // get existing rocrd
        //            var registration = registrationDAL.GetRegistrationById(RegistrationId);
        //            var filenamenew = RegistrationId + "_" + filename;
        //           // var filenamenew1 = RegistrationId + "_" + filename1;



        //            if (registration.Photo.ToLower() != filenamenew.ToLower())
        //                if (registration.Sign.ToLower() != filenamenew.ToLower())
        //                {
        //                File.Delete(theDirectory + "/Content/Registration" + "/" + registration.Photo);
        //                    File.Delete(theDirectory + "/Content/Registration" + "/" + registration.Sign);

        //                    registration.Photo = RegistrationId + "_" + filename;
        //                    registration.Sign = RegistrationId + "_" + filename;
        //                    var result = registrationDAL.UpdateRegistration(registration);
                           

        //                }

                    

                    
                   


               
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}


        //[HttpPost]
        //public async Task<IHttpActionResult> SaveRegistrationSign(int RegistrationId)
        //{
        //    try
        //    {
        //        if (!Request.Content.IsMimeMultipartContent())
        //            throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);

        //        var provider = new MultipartMemoryStreamProvider();
        //        await Request.Content.ReadAsMultipartAsync(provider);
        //        foreach (var file in provider.Contents)
        //        {
        //            var filename1 = file.Headers.ContentDisposition.FileName.Trim('\"');
        //            var buffer = await file.ReadAsByteArrayAsync();
        //            string fullPath = (new System.Uri(Assembly.GetExecutingAssembly().CodeBase)).AbsolutePath;
        //            //get the folder that's in
        //            string theDirectory = Path.GetDirectoryName(fullPath);
        //            theDirectory = theDirectory.Substring(0, theDirectory.LastIndexOf('\\'));
        //            File.WriteAllBytes(theDirectory + "/Content/Registration" + "/" + RegistrationId + "_" + filename1, buffer);
        //            //Do whatever you want with filename and its binary data.

        //            // get existing rocrd
        //            var registration = registrationDAL.GetRegistrationById(RegistrationId);
        //            var filenamenew = RegistrationId + "_" + filename1;


        //            if (registration.Sign.ToLower() != filenamenew.ToLower())

        //            {
        //                File.Delete(theDirectory + "/Content/Registration" + "/" + registration.Sign);

        //                registration.Sign = RegistrationId + "_" + filename1;

        //                var result = registrationDAL.UpdateRegistration(registration);

        //            }

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage(ex.Message);
        //    }

        //    return Ok();
        //}

    }
}