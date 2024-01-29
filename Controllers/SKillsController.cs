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
    public class SKillsController : ApiController
    {
        // GET: SKills
        public Logger Log = null;
        public SKillsController()
        {
            Log = Logger.GetLogger();
        }
        SKillsDAL sKillsDAL = new SKillsDAL();

        [HttpGet]
        [ActionName("GetAllSKills")]

        public List<SKills> GetAllSKills()
        {
            Log.writeMessage("SKillsController GetAllSKills Start");
            List<SKills> list = null;
            try
            {
                list = sKillsDAL.GetAllSKills();
            }
            catch (Exception ex)
            {
                Log.writeMessage("SKillsController GetAllSKills Error " + ex.Message);
            }
            Log.writeMessage("SKillsController GetAllSKills End");
            return list;

        }

        [HttpPost]
        [ActionName("AddSKills")]
        public IHttpActionResult AddSKills(SKills sKills)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                sKills.CreatedBy = "Admin";
                sKills.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                sKills.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                sKills.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = sKillsDAL.AddSKills(sKills);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SKillsController AddSKills Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateSKills")]
        public IHttpActionResult UpdateSKills(SKills sKills)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                sKills.CreatedBy = "Admin";
                sKills.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                sKills.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                sKills.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = sKillsDAL.UpdateSKills(sKills);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("SKillsController UpdateSKills Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetSKillsById")]
        public SKills GetSKillsById(int SKillsId)
        {
            Log.writeMessage("GetSKillsController GetSKillsById Start");
            SKills sKills = null;
            try
            {
                sKills = sKillsDAL.GetSKillsById(SKillsId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetSKillsController GetSKillsById Error " + ex.Message);
            }
            Log.writeMessage("GetSKillsController GetSKillsById End");
            return sKills;
        }
        public IHttpActionResult DeleteSKills(int SKillsId)
        {
            try
            {
                var result = sKillsDAL.DeleteSKills(SKillsId);

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
                Log.writeMessage("SKillsController DeleteSKills Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}