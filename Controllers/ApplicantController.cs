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
    public class ApplicantController : ApiController
    {
        public Logger Log = null;
        public ApplicantController()
        {
            Log = Logger.GetLogger();
        }
        ApplicantDAL applicantDAL = new ApplicantDAL();

        [HttpGet]
        [ActionName("GetAllApplicant")]

        public List<Applicant> GetAllApplicant()
        {
            Log.writeMessage("ApplicantController GetAllApplicant Start");
            List<Applicant> list = null;
            try
            {
                list = applicantDAL.GetAllApplicant();
            }
            catch (Exception ex)
            {
                Log.writeMessage("ApplicantController GetAllApplicant Error " + ex.Message);
            }
            Log.writeMessage("ApplicantController GetAllApplicant End");
            return list;

        }

        [HttpPost]
        [ActionName("AddApplicant")]
        public IHttpActionResult AddApplicant(Applicant applicant)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                applicant.CreatedBy = "Admin";
                applicant.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                applicant.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                applicant.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = applicantDAL.AddApplicant(applicant);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ApplicantController AddApplicant Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateApplicant")]
        public IHttpActionResult UpdateApplicant(Applicant applicant)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                applicant.CreatedBy = "Admin";
                applicant.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                applicant.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                applicant.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = applicantDAL.UpdateApplicant(applicant);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("ApplicantController UpdateApplicant Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetApplicantById")]
        public Applicant GetApplicantById(int ApplicantId)
        {
            Log.writeMessage("GetApplicantController GetApplicantById Start");
            Applicant applicant = null;
            try
            {
                applicant = applicantDAL.GetApplicantById(ApplicantId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetApplicantController GetApplicantById Error " + ex.Message);
            }
            Log.writeMessage("GetApplicantController GetApplicantById End");
            return applicant;
        }
        public IHttpActionResult DeleteApplicant(int ApplicantId)
        {
            try
            {
                var result = applicantDAL.DeleteApplicant(ApplicantId);

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
                Log.writeMessage("ApplicantController DeleteApplicant Error " + ex.Message);
            }
            return Ok("Failed");

        }
    }
}