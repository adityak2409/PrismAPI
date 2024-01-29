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
    public class BranchCodeController : ApiController
    {
        public Logger Log = null;
        // GET: CollegeCode
        public BranchCodeController()
        {
            Log = Logger.GetLogger();
        }
        BranchCodeDAL branchCodeDAL = new BranchCodeDAL();

        [HttpGet]
        [ActionName("GetAllBranchCode")]
        public List<BranchCode> GetAllBranchCode()
        {
            Log.writeMessage("BranchCodeController GetAllBranchCode Start");
            List<BranchCode> list = null;
            try
            {
                list = branchCodeDAL.GetAllBranchCode();
            }
            catch (Exception ex)
            {
                Log.writeMessage("BranchCodeController GetAllBranchCode Error " + ex.Message);
            }
            Log.writeMessage("BranchCodeController GetAllBranchCode End");
            return list;
        }

        [HttpGet]
        [ActionName("GetBranchCodeById")]
        public BranchCode GetBranchCodeById(int Id)
        {
            Log.writeMessage("BranchCodeController GetBranchCodeById Start");
            BranchCode branchCode = null;
            try
            {
                branchCode  = branchCodeDAL.GetBranchCodeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("BranchCodeController GetBranchCodeById Error " + ex.Message);
            }
            Log.writeMessage("BranchCodeController GetBranchCodeById End");
            return branchCode;
        }



        [HttpPost]
        [ActionName("AddBranchCode")]
        public IHttpActionResult AddBranchCode(BranchCode branchCode)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                branchCode.CreatedBy = "Admin";
                branchCode.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                branchCode.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                branchCode.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = branchCodeDAL.AddBranchCode(branchCode);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BranchCodeController AddBranchCode Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateBranchCode")]
        public IHttpActionResult UpdateBranchCode(BranchCode branchCode)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                branchCode.CreatedBy = "Admin";
                branchCode.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                branchCode.UpdatedBy = "Admin";
                branchCode.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = branchCodeDAL.UpdateBranchCode(branchCode);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("BranchCodeController AddBranchCode Error " + ex.Message);
            }
            return Ok(result);
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

        public IHttpActionResult DeleteBranchCode(int Id)
        {
            try
            {
                var result = branchCodeDAL.DeleteBranchCode(Id);

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
                Log.writeMessage("BranchCodeController DeleteBranchCode Error " + ex.Message);
            }
            return Ok("Failed");
        }


        // [HttpPost]
        //public async Task<IActionResult> SendMail([FromBody] Email email)
        //{
        //  Console.WriteLine("Sending email");
        //var client = new System.Net.Mail.SmtpClient("smtp.example.com", 111);
        //  client.UseDefaultCredentials = false;
        // client.EnableSsl = true;
        // client.Credentials = new System.Net.NetworkCredential(emailid, password);
        //var mailMessage = new System.Net.Mail.MailMessage();
        //mailMessage.From = new System.Net.Mail.MailAddress(senderemail);
        //mailMessage.To.Add(email.To);
        // mailMessage.Body = email.Text;
        // await client.SendMailAsync(mailMessage);
        //return Ok();
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

    }
}