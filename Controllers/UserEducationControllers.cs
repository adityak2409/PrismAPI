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


namespace PrismAPI.UserEducationControllers
{
    public class UserEducationController : ApiController
    {
        // GET: LoginCode
        public Logger Log = null;
        public UserEducationController()
        {
            Log = Logger.GetLogger();
        }

        UserEducationDAL usereducationDAL = new UserEducationDAL();

        [HttpGet]
        [ActionName("GetAllUserEducation")]
        public List<UserEducation> GetAllUserEducation()
        {
            Log.writeMessage("UserEducationController GetAllAcheivement Start");
            List<UserEducation> list = null;
            try
            {
                list = usereducationDAL.GetAllUserEducation();
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserEducationController GetAllUserEducation Error " + ex.Message);
            }
            Log.writeMessage("UserEducationController GetAllUserEducation End");
            return list;
        }

        [HttpGet]
        [ActionName("GetUserEducationById")]
        public UserEducation GetUserEducationById(int UserEducationId)
        {
            Log.writeMessage("UserEducationController GetUserEducationById Start");
            UserEducation usereducation = null;
            try
            {
                usereducation = usereducationDAL.GetUserEducationById(UserEducationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserEducationController GetUserEducationById Error " + ex.Message);
            }
            Log.writeMessage("UserEducationController GetUserEducationById End");
            return usereducation;
        }

        /* [HttpGet]
         [ActionName("GetLoginCodeByEmail")]
         public LoginCode GetLoginCodeByEmail(string Email)
         {
             Log.writeMessage("LoginCodeController GetLoginCodeByEmail Start");
             LoginCode loginCode = null;
             try
             {
                 loginCode = loginCodeDAL.GetLoginCodeByEmail(Email);
             }
             catch (Exception ex)
             {
                 Log.writeMessage("LoginCodeController GetLoginCodeByEmail Error " + ex.Message);
             }
             Log.writeMessage("LoginCodeController GetLoginCodeByEmail End");
             return loginCode;
         }*/

        [HttpPost]
        [ActionName("AddUserEducation")]
        public IHttpActionResult AddUserEducation(UserEducation usereducation)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                usereducation.CreatedBy = "Admin";
                usereducation.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                usereducation.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                usereducation.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = usereducationDAL.AddUserEducation(usereducation);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserEducationController AddUserEducation Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateUserEducation")]
        public IHttpActionResult UpdateUserEducation(UserEducation usereducation)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                usereducation.CreatedBy = "Admin";
                usereducation.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                usereducation.UpdatedBy = "Admin";
                usereducation.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = usereducationDAL.UpdateUserEducation(usereducation);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserEducationController AddUserEducation Error " + ex.Message);
            }
            return Ok(result);
        }

        /*
                [HttpGet]
                [ActionName("Login")]
                public Loginc Loginc(string Email, string Password)
                {
                    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
                    Loginc user = null;
                    try
                    {
                        user = loginCodeDAL.Loginc(Email, Password);
                    }
                    catch (Exception ex)
                    {
                        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
                    }
                    Log.writeMessage("LoginCodeController GetLoginCodeById End");
                    return user;
                }

                [HttpGet]
                [ActionName("OtpNo")]
                public OtpNo OtpNo(string Mobile)
                {
                    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
                    OtpNo OtpNo = null;
                    try
                    {
                        OtpNo = loginCodeDAL.OtpNo(Mobile);
                    }
                    catch (Exception ex)
                    {
                        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
                    }
                    Log.writeMessage("LoginCodeController GetLoginCodeById End");
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

        public IHttpActionResult DeleteUserEducation(int Id)
        {
            try
            {
                var result = usereducationDAL.DeleteUserEducation(Id);

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
                Log.writeMessage("UserEducationController DeleteUserEducation Error " + ex.Message);
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
         public async Task<IHttpActionResult> SaveLoginCodeImage(int Id)
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
                     File.WriteAllBytes(theDirectory + "/Content/LoginCode" + "/" + Id + "_" + filename, buffer);
                     //Do whatever you want with filename and its binary data.

                     // get existing rocrd
                     var loginCode = loginCodeDAL.GetLoginCodeById(Id);
                     var filenamenew = Id + "_" + filename;
                     if (loginCode.Photo.ToLower() != filenamenew.ToLower())
                     {
                         File.Delete(theDirectory + "/Content/LoginCode" + "/" + loginCode.Photo);
                         loginCode.Photo = Id + "_" + filename;
                         var result = loginCodeDAL.UpdateLoginCode(loginCode);

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
