using PrismAPI.DAL;
using PrismAPI.Models;
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

namespace PrismAPI.Controllers
{
    public class ApplicationTrackerController : ApiController
    {
        // GET: ApplicationTracker
        public Logger Log = null;
        public ApplicationTrackerController()
        {
            Log = Logger.GetLogger();
        }
        ApplicationTrackerDAL applicationTrackerDAL = new ApplicationTrackerDAL();

        [HttpGet]
        [ActionName("GetAllApplicationTracker")]

        public List<ApplicationTracker> GetAllApplicationTracker()
        {
            Log.writeMessage("ApplicationTrackerController GetAllApplicationTracker Start");
            List<ApplicationTracker> list = null;
            try
            {
                list = applicationTrackerDAL.GetAllApplicationTracker();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ApplicationTrackerController GetAllApplicationTracker Error " + ex.Message);
            }
            Log.writeMessage("ApplicationTrackerController GetAllApplicationTracker End");
            return list;

        }

        [HttpPost]
        [ActionName("AddApplicationTracker")]
        public IHttpActionResult AddApplicationTracker(ApplicationTracker applicationTracker)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                applicationTracker.CreatedBy = "Admin";
                applicationTracker.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                applicationTracker.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                applicationTracker.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = applicationTrackerDAL.AddApplicationTracker(applicationTracker);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ApplicationTrackerController AddApplicationTracker Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateApplicationTracker")]
        public IHttpActionResult UpdateApplicationTracker(ApplicationTracker applicationTracker)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                applicationTracker.CreatedBy = "Admin";
                applicationTracker.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                applicationTracker.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                applicationTracker.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = applicationTrackerDAL.UpdateApplicationTracker(applicationTracker);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ApplicationTrackerController UpdateApplicationTracker Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetApplicationTrackerById")]
        public ApplicationTracker GetApplicationTrackerById(int ApplicationTrackerId)
        {
            Log.writeMessage("GetApplicationTrackerController GetApplicationTrackerById Start");
            ApplicationTracker applicationTracker = null;
            try
            {
                applicationTracker = applicationTrackerDAL.GetApplicationTrackerById(ApplicationTrackerId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetApplicationTrackerController GetApplicationTrackerById Error " + ex.Message);
            }
            Log.writeMessage("GetApplicationTrackerController GetApplicationTrackerById End");
            return applicationTracker;
        }
        public IHttpActionResult DeleteApplicationTracker(int ApplicationTrackerId)
        {
            try
            {
                var result = applicationTrackerDAL.DeleteApplicationTracker(ApplicationTrackerId);

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
                Log.writeMessage("ApplicationTrackerController DeleteApplicationTracker Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}