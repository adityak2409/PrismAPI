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
    public class CVController : ApiController
    {
        // GET: CV
        public Logger Log = null;
        public CVController()
        {
            Log = Logger.GetLogger();
        }

        CVDAL cVDAL = new CVDAL();

        [HttpGet]
        [ActionName("GetAllCV")]
        public List<CV> GetAllCV()
        {
            Log.writeMessage("CVController GetAllCV Start");
            List<CV> list = null;
            try
            {
                list = cVDAL.GetAllCV();
            }
            catch (Exception ex)
            {
                Log.writeMessage("CVController GetAllCV Error " + ex.Message);
            }
            Log.writeMessage("CVController GetAllCV End");
            return list;
        }

        [HttpGet]
        [ActionName("GetCVById")]
        public CV GetCVById(int CVId)
        {
            Log.writeMessage("CVController GetCVById Start");
            CV cV = null;
            try
            {
                cV = cVDAL.GetCVById(CVId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("CVController GetCVById Error " + ex.Message);
            }
            Log.writeMessage("CVController GetCVById End");
            return cV;
        }

       

        [HttpPost]
        [ActionName("AddCV")]
        public IHttpActionResult AddCV(CV cV)
        
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                cV.CreatedBy = "Admin";
                cV.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                cV.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                cV.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = cVDAL.AddCV(cV);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CVController AddCV Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateCV")]
        public IHttpActionResult UpdateCV(CV cV)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                cV.CreatedBy = "Admin";
                cV.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                cV.UpdatedBy = "Admin";
                cV.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = cVDAL.UpdateCV(cV);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CVController AddCV Error " + ex.Message);
            }
            return Ok(result);
        }

        //// DELETE: api/Address/5

        public IHttpActionResult DeleteCV(int CVId)
        {
            try
            {
                var result = cVDAL.DeleteCV(CVId);

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
                Log.writeMessage("CVController DeleteCV Error " + ex.Message);
            }
            return Ok("Failed");
        }

        //[HttpGet]
        //[ActionName("Login")]
        //public Loginc Loginc(string Email, string Password)
        //{
        //    Log.writeMessage("CVController GetLoginCodeById Start");
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
        public async Task<IHttpActionResult> SaveCVImage(int CVId)
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
                    File.WriteAllBytes(theDirectory + "/Content/CV" + "/" + CVId + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var cV = cVDAL.GetCVById(CVId);
                    var filenamenew = CVId + "_" + filename;
                    if (cV.CVPDF.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/CV" + "/" + cV.CVPDF);
                        cV.CVPDF = CVId + "_" + filename;
                        var result = cVDAL.UpdateCV(cV);

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