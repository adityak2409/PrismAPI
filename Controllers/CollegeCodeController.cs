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
    public class CollegeCodeController : ApiController
    {
        public Logger Log = null;
        // GET: CollegeCode
        public CollegeCodeController()
        {
             Log = Logger.GetLogger();
        }
        CollegeCodeDAL collegeCodeDAL = new CollegeCodeDAL();

        [HttpGet]
        [ActionName("GetAllCollegeCode")]
        public List<CollegeCode> GetAllCollegeCode()
        {
            Log.writeMessage("CollegeCodeController GetAllCollegeCode Start");
            List<CollegeCode> list = null;
            try
            {
                list = collegeCodeDAL.GetAllCollegeCode();
            }
            catch (Exception ex)
            {
                Log.writeMessage("CollegeCodeController GetAllCollegeCode Error " + ex.Message);
            }
            Log.writeMessage("CollegeCodeController GetAllCollegeCode End");
            return list;
        }

        [HttpGet]
        [ActionName("GetCollegeCodeById")]
        public CollegeCode GetCollegeCodeById(int Id)
        {
            Log.writeMessage("CollegeCodeController GetCollegeCodeById Start");
            CollegeCode collegeCode = null;
            try
            {
                collegeCode = collegeCodeDAL.GetCollegeCodeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("CollegeCodeController GetCollegeCodeById Error " + ex.Message);
            }
            Log.writeMessage("CollegeCodeController GetCollegeCodeById End");
            return collegeCode;
        }



        [HttpPost]
        [ActionName("AddCollegeCode")]
        public IHttpActionResult AddCollegeCode(CollegeCode collegeCode)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                collegeCode.CreatedBy = "Admin";
                collegeCode.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                collegeCode.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                collegeCode.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = collegeCodeDAL.AddCollegeCode(collegeCode);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CollegeCodeController AddCollegeCode Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateCollegeCode")]
        public IHttpActionResult UpdateCollegeCode(CollegeCode collegeCode)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                collegeCode.CreatedBy = "Admin";
                collegeCode.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                collegeCode.UpdatedBy = "Admin";
                collegeCode.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = collegeCodeDAL.UpdateCollegeCode(collegeCode);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CollegeCodeController AddCollegeCode Error " + ex.Message);
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

        public IHttpActionResult DeleteCollegeCode(int Id)
        {
            try
            {
                var result = collegeCodeDAL.DeleteCollegeCode(Id);

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
                Log.writeMessage("CollegeCodeController DeleteCollegeCode Error " + ex.Message);
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


        [HttpPost]
        public async Task<IHttpActionResult> SaveProfilePhoto(int Id)
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

                    File.WriteAllBytes(theDirectory + "/ProfilePhoto/" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.
                }
            }
            catch (Exception ex)
            {
                Log.writeMessage(ex.Message);
            }

            return Ok();
        }

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