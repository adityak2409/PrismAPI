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
    public class EnrollmentController : ApiController
    {
        public Logger Log = null;
        public EnrollmentController()
        {
            Log = Logger.GetLogger();
        }
        EnrollmentDAL enrollmentDAL = new EnrollmentDAL();

        [HttpGet]
        [ActionName("GetAllEnrollment")]

        public List<Enrollment> GetAllEnrollment()
        {
            Log.writeMessage("EnrollmentController GetAllEnrollment Start");
            List<Enrollment> list = null;
            try
            {
                list = enrollmentDAL.GetAllEnrollment();
            }
            catch (Exception ex)
            {
                Log.writeMessage("EnrollmentController GetAllEnrollment Error " + ex.Message);
            }
            Log.writeMessage("EnrollmentController GetAllEnrollment End");
            return list;

        }

        [HttpPost]
        [ActionName("AddEnrollment")]
        public IHttpActionResult AddEnrollment(Enrollment enrollment)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                enrollment.CreatedBy = "Admin";
                enrollment.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                enrollment.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                enrollment.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = enrollmentDAL.AddEnrollment(enrollment);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EnrollmentController AddEnrollment Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateEnrollment")]
        public IHttpActionResult UpdateEnrollment(Enrollment enrollment)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                enrollment.CreatedBy = "Admin";
                enrollment.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                enrollment.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                enrollment.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = enrollmentDAL.UpdateEnrollment(enrollment);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EnrollmentController UpdateEnrollment Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetEnrollmentById")]
        public Enrollment GetEnrollmentById(int EnrollmentId)
        {
            Log.writeMessage("GetEnrollmentController GetEnrollmentById Start");
            Enrollment enrollment = null;
            try
            {
                enrollment = enrollmentDAL.GetEnrollmentById(EnrollmentId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetEnrollmentController GetEnrollmentById Error " + ex.Message);
            }
            Log.writeMessage("GetEnrollmentController GetEnrollmentById End");
            return enrollment;
        }
        public IHttpActionResult DeleteEnrollment(int EnrollmentId)
        {
            try
            {
                var result = enrollmentDAL.DeleteEnrollment(EnrollmentId);

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
                Log.writeMessage("EnrollmentController DeleteEnrollment Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}