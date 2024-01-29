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
    public class CourseController : ApiController
    {
        public Logger Log = null;
        public CourseController()
        {
            Log = Logger.GetLogger();
        }
        CourseDAL courseDAL = new CourseDAL();

        [HttpGet]
        [ActionName("GetAllCourse")]

        public List<Course> GetAllCourse()
        {
            Log.writeMessage("CourseController GetAllCourse Start");
            List<Course> list = null;
            try
            {
                list = courseDAL.GetAllCourse();
            }
            catch (Exception ex)
            {
                Log.writeMessage("CourseController GetAllCourse Error " + ex.Message);
            }
            Log.writeMessage("CourseController GetAllCourse End");
            return list;

        }

        [HttpPost]
        [ActionName("AddCourse")]
        public IHttpActionResult AddCourse(Course course)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                course.CreatedBy = "Admin";
                course.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                course.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                course.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = courseDAL.AddCourse(course);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CourseController AddCourse Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateCourse")]
        public IHttpActionResult UpdateCourse(Course course)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                course.CreatedBy = "Admin";
                course.UpdatedBy = "Admin";
                course.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = courseDAL.UpdateCourse(course);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CourseController AddCourse Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetCourseById")]
        public Course GetCourseById(int CourseId)
        {
            Log.writeMessage("CourseController GetCourseById Start");
            Course course = null;
            try
            {
                course = courseDAL.GetCourseById(CourseId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("CourseController GetCourseById Error " + ex.Message);
            }
            Log.writeMessage("CourseController GetCourseById End");
            return course;
        }
        public IHttpActionResult DeleteCourse(int CourseId)
        {
            try
            {
                var result = courseDAL.DeleteCourse(CourseId);

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
                Log.writeMessage("CourseController DeleteCourse Error " + ex.Message);
            }
            return Ok("Failed");
        }
        //[HttpGet]
        //[ActionName("Login")]
        //public LoginCo Login(string Email, string Password)
        //{
        //    Log.writeMessage("CourseController Login Start");
        //    LoginCo user = null;
        //    try
        //    {
        //        user = courseDAL.Login(Email, Password);
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
        //    }
        //    Log.writeMessage("RegistrationController GetRegistrationById End");
        //    return user;
        //}

    }
}