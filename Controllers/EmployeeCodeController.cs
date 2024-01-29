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

    public class EmployeeCodeController : ApiController
    {
        public Logger Log = null;
        public EmployeeCodeController()
        {
            Log = Logger.GetLogger();
        }
        EmployeeCodeDAL employeeCodeDAL = new EmployeeCodeDAL();

        [HttpGet]
        [ActionName("GetAllEmployeeCode")]

        public List<EmployeeCode> GetAllEmployeeCode()
        {
            Log.writeMessage("EmployeeController GetAllEmployeeCode Start");
            List<EmployeeCode> list = null;
            try
            {
                list = employeeCodeDAL.GetAllEmployeeCode();
            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeeCodeController GetAllEmployeeCode Error " + ex.Message);
            }
            Log.writeMessage("EmployeeCodeController GetAllEmployeeCode End");
            return list;

        }

        [HttpPost]
        [ActionName("AddEmployeeCode")]
        public IHttpActionResult AddEmployeeCode(EmployeeCode employeeCode)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                employeeCode.CreatedBy = "Admin";
                employeeCode.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                employeeCode.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                employeeCode.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = employeeCodeDAL.AddEmployeeCode(employeeCode);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeeCodeController AddEmployeeCode Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateEmployeeCode")]
        public IHttpActionResult UpdateEmployeeCode(EmployeeCode employeeCode)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                employeeCode.CreatedBy = "Admin";
                employeeCode.UpdatedBy = "Admin";
                employeeCode.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = employeeCodeDAL.UpdateEmployeeCode(employeeCode);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeeCodeController AddEmployeeCode Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetEmployeeCodeById")]
        public EmployeeCode GetEmployeeCodeById(int Id)
        {
            Log.writeMessage("EmployeeCodeController GetEmployeeCodeById Start");
            EmployeeCode employeeCode = null;
            try
            {
                employeeCode = employeeCodeDAL.GetEmployeeCodeById(Id);
            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployeeCodeController GetEmployeeCodeById Error " + ex.Message);
            }
            Log.writeMessage("EmployeeCodeController GetEmployeeCodeById End");
            return employeeCode;
        }
        public IHttpActionResult DeleteEmployeeCode(int Id)
        {
            try
            {
                var result = employeeCodeDAL.DeleteEmployeeCode(Id);

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
                Log.writeMessage("EmployeeCodeController DeleteEmployeeCode Error " + ex.Message);
            }
            return Ok("Failed");
        }


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
        public async Task<IHttpActionResult> SaveEmployeeCodeImage(int Id)
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
                    File.WriteAllBytes(theDirectory + "/Content/EmployeeCode" + "/" + Id + "_" + filename, buffer);
                    //Do whatever you want with filename and its binary data.

                    // get existing rocrd
                    var employeeCode = employeeCodeDAL.GetEmployeeCodeById(Id);
                    var filenamenew = Id + "_" + filename;
                    if (employeeCode.Photo.ToLower() != filenamenew.ToLower())
                    {
                        File.Delete(theDirectory + "/Content/EmployeeCode" + "/" + employeeCode.Photo);
                        employeeCode.Photo = Id + "_" + filename;
                        var result = employeeCodeDAL.UpdateEmployeeCode(employeeCode);

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