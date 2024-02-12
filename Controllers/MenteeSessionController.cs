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
    public class MenteeSessionController : ApiController
    {
        // GET: MenteeSession
        public Logger Log = null;
        public MenteeSessionController()
        {
            Log = Logger.GetLogger();
        }
        MenteeSessionDAL menteeSessionDAL = new MenteeSessionDAL();

        [HttpGet]
        [ActionName("GetAllMenteeSession")]

        public List<MenteeSession> GetAllMenteeSession()
        {
            Log.writeMessage("MenteeSessionController GetAllMenteeSession Start");
            List<MenteeSession> list = null;
            try
            {
                list = menteeSessionDAL.GetAllMenteeSession();
            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSessionController GetAllMenteeSession Error " + ex.Message);
            }
            Log.writeMessage("MenteeSessionController GetAllMenteeSession End");
            return list;

        }

        [HttpPost]
        [ActionName("AddMenteeSession")]
        public IHttpActionResult AddMenteeSession(MenteeSession menteeSession)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                menteeSession.CreatedBy = "Admin";
                menteeSession.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                menteeSession.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                menteeSession.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = menteeSessionDAL.AddMenteeSession(menteeSession);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSessionController AddMenteeSession Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateMenteeSession")]
        public IHttpActionResult UpdateMenteeSession(MenteeSession menteeSession)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                menteeSession.CreatedBy = "Admin";
                menteeSession.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                menteeSession.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                menteeSession.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = menteeSessionDAL.UpdateMenteeSession(menteeSession);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("MenteeSessionController UpdateMenteeSession Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpGet]
        [ActionName("GetMenteeSessionById")]
        public MenteeSession GetMenteeSessionById(int MenteeSessionId)
        {
            Log.writeMessage("GetMenteeSessionController GetMenteeSessionById Start");
            MenteeSession menteeSession = null;
            try
            {
                menteeSession = menteeSessionDAL.GetMenteeSessionById(MenteeSessionId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("GetMenteeSessionController GetMenteeSessionById Error " + ex.Message);
            }
            Log.writeMessage("GetMenteeSessionController GetMenteeSessionById End");
            return menteeSession;
        }
        public IHttpActionResult DeleteMenteeSession(int MenteeSessionId)
        {
            try
            {
                var result = menteeSessionDAL.DeleteMenteeSession(MenteeSessionId);

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
                Log.writeMessage("MenteeSessionController DeleteMenteeSession Error " + ex.Message);
            }
            return Ok("Failed");
        }
    }
}