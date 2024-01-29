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

namespace PrismAPI.Controllers
{
    public class EndUserPlanController : ApiController
    {
        public Logger Log = null;
        public EndUserPlanController()
        {
            Log = Logger.GetLogger();
        }

        EndUserPlanDAL endUserPlanDAL = new EndUserPlanDAL();

        [HttpGet]
        [ActionName("GetAllEndUserPlan")]
        public List<EndUserPlan> GetAllEndUserPlan()
        {
            Log.writeMessage("EndUserPlanController GetAllEndUserPlan Start");
            List<EndUserPlan> list = null;
            try
            {
                list = endUserPlanDAL.GetAllEndUserPlan();
            }
            catch (Exception ex)
            {
                Log.writeMessage("EndUserPlanController GetAllEndUserPlan Error " + ex.Message);
            }
            Log.writeMessage("EndUserPlanController GetAllEndUserPlan End");
            return list;
        }

        [HttpGet]
        [ActionName("GetEndUserPlanById")]
        public EndUserPlan GetEndUserPlanById(int EndUserPlanId)
        {
            Log.writeMessage("EndUserPlanController GetEndUserPlanById Start");
            EndUserPlan endUserPlan = null;
            try
            {
                endUserPlan = endUserPlanDAL.GetEndUserPlanById(EndUserPlanId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("EndUserPlanController GetEndUserPlanById Error " + ex.Message);
            }
            Log.writeMessage("EndUserPlanController GetEndUserPlanById End");
            return endUserPlan;
        }

        //[HttpGet]
        //[ActionName("GetEndUserPlanByEmail")]
        //public EndUserPlan GetEndUserPlanByEmail(string Email)
        //{
        //    Log.writeMessage("EndUserPlanController GetEndUserPlanByEmail Start");
        //    EndUserPlan endUserPlan = null;
        //    try
        //    {
        //        loginCode = loginCodeDAL.GetLoginCodeByEmail(Email);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("LoginCodeController GetLoginCodeByEmail Error " + ex.Message);
        //    }
        //    Log.writeMessage("LoginCodeController GetLoginCodeByEmail End");
        //    return loginCode;
        //}

        [HttpPost]
        [ActionName("AddEndUserPlan")]
        public IHttpActionResult AddEndUserPlan(EndUserPlan endUserPlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                endUserPlan.CreatedBy = "Admin";
                endUserPlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                endUserPlan.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                endUserPlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = endUserPlanDAL.AddEndUserPlan(endUserPlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EndUserPlanController AddEndUserPlan Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateEndUserPlan")]
        public IHttpActionResult UpdateEndUserPlan(EndUserPlan endUserPlan)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                endUserPlan.CreatedBy = "Admin";
                endUserPlan.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                endUserPlan.UpdatedBy = "Admin";
                endUserPlan.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = endUserPlanDAL.UpdateEndUserPlan(endUserPlan);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EndUserPlanController AddEndUserPlan Error " + ex.Message);
            }
            return Ok(result);
        }


        //[HttpGet]
        //[ActionName("Login")]
        //public Loginc Loginc(string Email, string Password)
        //{
        //    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
        //    Loginc user = null;
        //    try
        //    {
        //        user = loginCodeDAL.Loginc(Email, Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
        //    }
        //    Log.writeMessage("LoginCodeController GetLoginCodeById End");
        //    return user;
        //}

        //[HttpGet]
        //[ActionName("OtpNo")]
        //public OtpNo OtpNo(string Mobile)
        //{
        //    Log.writeMessage("LoginCodeController GetLoginCodeById Start");
        //    OtpNo OtpNo = null;
        //    try
        //    {
        //        OtpNo = loginCodeDAL.OtpNo(Mobile);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("LoginCodeController GetLoginCodeById Error " + ex.Message);
        //    }
        //    Log.writeMessage("LoginCodeController GetLoginCodeById End");
        //    return OtpNo;
        //}
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

        //public IHttpActionResult DeleteFirstModel(int Id)
        //{
        //    try
        //    {
        //        var result = firstDAL.DeleteFirstModel(Id);

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
        //        Log.writeMessage("FirstController DeleteFirstModel Error " + ex.Message);
        //    }
        //    return Ok("Failed");
        //}


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


        [HttpPost]
        public async Task<IHttpActionResult> SaveEndUserPlanImage(int EndUserPlanId)
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
                    File.WriteAllBytes(theDirectory + "/Content/EndUserPlan" + "/" + EndUserPlanId + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var endUserPlan = endUserPlanDAL.GetEndUserPlanById(EndUserPlanId);
                    var filenamenew = EndUserPlanId + "_" + filename;
                    if (endUserPlan.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/EndUserPlan" + "/" + endUserPlan.Photo);
                        endUserPlan.Photo = EndUserPlanId + "_" + filename;
                        var result = endUserPlanDAL.UpdateEndUserPlan(endUserPlan);

                    }
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();
        }
    }
}