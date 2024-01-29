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
    public class IndustryController : ApiController
    {
        // GET: Industry
        public Logger Log = null;
        public IndustryController()
        {
            Log = Logger.GetLogger();
        }
        IndustryDAL industryDAL = new IndustryDAL();

        [HttpGet]
        [ActionName("GetAllIndustry")]

        public List<Industry> GetAllIndustry()
        {
            Log.writeMessage("IndustryController GetAllIndustry Start");
            List<Industry> list = null;
            try
            {
                list = industryDAL.GetAllIndustry();
            }
            catch (Exception ex)
            {
                Log.writeMessage("IndustryController GetAllIndustry Error " + ex.Message);
            }
            Log.writeMessage("IndustryController GetAllIndustry End");
            return list;

        }

        [HttpPost]
        [ActionName("AddIndustry")]
        public IHttpActionResult AddIndustry(Industry industry)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                industry.CreatedBy = "Admin";
                industry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                industry.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                industry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = industryDAL.AddIndustry(industry);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("IndustryController AddIndustry Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateIndustry")]
        public IHttpActionResult UpdateIndustry(Industry industry)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                industry.CreatedBy = "Admin";
                industry.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                industry.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                industry.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = industryDAL.UpdateIndustry(industry);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("IndustryController UpdateIndustry Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetIndustryById")]
        public Industry GetIndustryById(int IndustryId)
        {
            Log.writeMessage("GetIndustryController GetIndustryById Start");
            Industry industry = null;
            try
            {
                industry = industryDAL.GetIndustryById(IndustryId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetIndustryController GetIndustryById Error " + ex.Message);
            }
            Log.writeMessage("GetIndustryController GetIndustryById End");
            return industry;
        }
        public IHttpActionResult DeleteIndustry(int IndustryId)
        {
            try
            {
                var result = industryDAL.DeleteIndustry(IndustryId);

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
                Log.writeMessage("IndustryController DeleteIndustry Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}