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
    public class CompanySessionController : ApiController
    {
        public Logger Log = null;
        public CompanySessionController()
        {
            Log = Logger.GetLogger();
        }
        CompanySessionDAL companySessionDAL = new CompanySessionDAL();

        [HttpGet]
        [ActionName("GetAllCompanySession")]

        public List<CompanySession> GetAllEmployeeCode()
        {
            Log.writeMessage("CompanySessionController GetAllCompanySession Start");
            List<CompanySession> list = null;
            try
            {
                list = companySessionDAL.GetAllCompanySession();
            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanySessionController GetAllCompanySession Error " + ex.Message);
            }
            Log.writeMessage("CompanySessionController GetAllCompanySession End");
            return list;

        }

        [HttpPost]
        [ActionName("AddCompanySession")]
        public IHttpActionResult AddCompanySession(CompanySession companySession)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                companySession.CreatedBy = "Admin";
                companySession.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                companySession.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                companySession.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = companySessionDAL.AddCompanySession(companySession);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanySessionController AddCompanySession Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateCompanySession")]
        public IHttpActionResult UpdateCompanySession(CompanySession companySession)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                companySession.CreatedBy = "Admin";
                companySession.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                companySession.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                companySession.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = companySessionDAL.UpdateCompanySession(companySession);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("CompanySessionController AddCompanySession Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetCompanySessionById")]
        public CompanySession GetCompanySessionById(int CompanySessionId)
        {
            Log.writeMessage("GetCompanySessionController GetCompanySessionById Start");
            CompanySession companySession = null;
            try
            {
                companySession = companySessionDAL.GetCompanySessionById(CompanySessionId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetCompanySessionController GetCompanySessionById Error " + ex.Message);
            }
            Log.writeMessage("GetCompanySessionController GetCompanySessionById End");
            return companySession;
        }
        public IHttpActionResult DeleteCompanySession(int CompanySessionId)
        {
            try
            {
                var result = companySessionDAL.DeleteCompanySession(CompanySessionId);

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
                Log.writeMessage("CompanySessionController DeleteGetCompanySession Error " + ex.Message);
            }
            return Ok("Failed");
        }


      

    }
}