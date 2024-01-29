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
    public class EmployerController : ApiController
    {
        // GET: Employer
        public Logger Log = null;
        public EmployerController()
        {
            Log = Logger.GetLogger();
        }
        EmployerDAL employerDAL = new EmployerDAL();

        [HttpGet]
        [ActionName("GetAllEmployer")]

        public List<Employer> GetAllEmployer()
        {
            Log.writeMessage("EmployerController GetAllEmployer Start");
            List<Employer> list = null;
            try
            {
                list = employerDAL.GetAllEmployer();
            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployerController GetAllEmployer Error " + ex.Message);
            }
            Log.writeMessage("EmployerController GetAllEmployer End");
            return list;

        }

        [HttpPost]
        [ActionName("AddEmployer")]
        public IHttpActionResult AddEmployer(Employer employer)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                employer.CreatedBy = "Admin";
                employer.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                employer.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                employer.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = employerDAL.AddEmployer(employer);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployerController AddEmployer Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateEmployer")]
        public IHttpActionResult UpdateEmployer(Employer employer)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                employer.CreatedBy = "Admin";
                employer.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                employer.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                employer.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = employerDAL.UpdateEmployer(employer);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("EmployerController UpdateEmployer Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetEmployerById")]
        public Employer GetEmployerById(int EmployerId)
        {
            Log.writeMessage("GetEmployerController GetEmployerById Start");
            Employer employer = null;
            try
            {
                employer = employerDAL.GetEmployerById(EmployerId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetEmployerController GetEmployerById Error " + ex.Message);
            }
            Log.writeMessage("GetEmployerController GetEmployerById End");
            return employer;
        }
        public IHttpActionResult DeleteEmployer(int EmployerId)
        {
            try
            {
                var result = employerDAL.DeleteEmployer(EmployerId);

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
                Log.writeMessage("EmployerController DeleteEmployer Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}