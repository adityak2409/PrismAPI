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
    public class InstructorController : ApiController
    {
        // GET: Instructor
        public Logger Log = null;
        public InstructorController()
        {
            Log = Logger.GetLogger();
        }
        InstructorDAL instructorDAL = new InstructorDAL();

        [HttpGet]
        [ActionName("GetAllInstructor")]

        public List<Instructor> GetAllInstructor()
        {
            Log.writeMessage("InstructorController GetAllInstructor Start");
            List<Instructor> list = null;
            try
            {
                list = instructorDAL.GetAllInstructor();
            }
            catch (Exception ex)
            {
                Log.writeMessage("InstructorController GetAllInstructor Error " + ex.Message);
            }
            Log.writeMessage("InstructorController GetAllInstructor End");
            return list;

        }

        [HttpPost]
        [ActionName("AddInstructor")]
        public IHttpActionResult AddInstructor(Instructor instructor)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                instructor.CreatedBy = "Admin";
                instructor.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                instructor.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                instructor.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = instructorDAL.AddInstructor(instructor);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("InstructorController AddInstructor Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateInstructor")]
        public IHttpActionResult UpdateInstructor(Instructor instructor)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                instructor.CreatedBy = "Admin";
                instructor.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                instructor.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                instructor.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = instructorDAL.UpdateInstructor(instructor);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("InstructorController UpdateInstructor Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetInstructorById")]
        public Instructor GetInstructorById(int InstructorId)
        {
            Log.writeMessage("GetInstructorController GetInstructorById Start");
            Instructor instructor = null;
            try
            {
                instructor = instructorDAL.GetInstructorById(InstructorId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetInstructorController GetInstructorById Error " + ex.Message);
            }
            Log.writeMessage("GetInstructorController GetInstructorById End");
            return instructor;
        }
        public IHttpActionResult DeleteInstructor(int InstructorId)
        {
            try
            {
                var result = instructorDAL.DeleteInstructor(InstructorId);

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
                Log.writeMessage("InstructorController DeleteInstructor Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}