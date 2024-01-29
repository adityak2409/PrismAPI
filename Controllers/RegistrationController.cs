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
    public class RegistrationController : ApiController
    {
        public Logger Log = null;
        public RegistrationController()
        {
            Log = Logger.GetLogger();
        }
        RegistrationDAL registrationDAL = new RegistrationDAL();

        [HttpGet]
        [ActionName("GetAllRegistration")]

        public List<Registration> GetAllRegistration()
        {
            Log.writeMessage("RegistrationController GetAllRegistration Start");
            List<Registration> list = null;
            try
            {
                list = registrationDAL.GetAllRegistration();
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetAllRegistration Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetAllRegistration End");
            return list;

        }

        [HttpPost]
        [ActionName("AddRegistration")]
        public IHttpActionResult AddRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                registration.CreatedBy = "Admin";
                registration.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                registration.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = registrationDAL.AddRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateRegistration")]
        public IHttpActionResult UpdateRegistration(Registration registration)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                registration.CreatedBy = "Admin";
                registration.UpdatedBy = "Admin";
                registration.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = registrationDAL.UpdateRegistration(registration);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController AddRegistration Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetRegistrationById")]
        public Registration GetRegistrationById(int RegistrationId)
        {
            Log.writeMessage("RegistrationController GetRegistrationById Start");
            Registration registration = null;
            try
            {
                registration = registrationDAL.GetRegistrationById(RegistrationId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return registration;
        }
        public IHttpActionResult DeleteRegistration(int RegistrationId)
        {
            try
            {
                var result = registrationDAL.DeleteRegistration(RegistrationId);

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
                Log.writeMessage("RegistrationController DeleteRegistration Error " + ex.Message);
            }
            return Ok("Failed");
        }
        [HttpGet]
        [ActionName("Login")]
        public LoginCo Login(string Email, string Password)
        {
            Log.writeMessage("RegistrationController Login Start");
            LoginCo user = null;
            try
            {
                user = registrationDAL.Login(Email,Password);
            }
            catch (Exception ex)
            {
                Log.writeMessage("RegistrationController GetRegistrationById Error " + ex.Message);
            }
            Log.writeMessage("RegistrationController GetRegistrationById End");
            return user;
        }
    }
}