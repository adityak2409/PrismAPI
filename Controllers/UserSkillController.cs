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
    public class UserSkillController : ApiController
    {
        public Logger Log = null;
        // GET: UserSkill
        public UserSkillController()
        {
            Log = Logger.GetLogger();
        }
        UserSkillDAL userSkillDAL = new UserSkillDAL();

        [HttpGet]
        [ActionName("GetAllUserSkill")]
        public List<UserSkill> GetAllUserSkill()
        {
            Log.writeMessage("UserSkillController GetAllUserSkill Start");
            List<UserSkill> list = null;
            try
            {
                list = userSkillDAL.GetAllUserSkill();
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController GetAllUserSkill Error " + ex.Message);
            }
            Log.writeMessage("UserSkillController GetAllUserSkill End");
            return list;
        }

        [HttpGet]
        [ActionName("GetUserSkillById")]
        public UserSkill GetUserSkillById(int UserSkillId)
        {
            Log.writeMessage("UserSkillController GetUserSkillById Start");
            UserSkill userSkill = null;
            try
            {
                userSkill = userSkillDAL.GetUserSkillById(UserSkillId);
            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController GetUserSkillById Error " + ex.Message);
            }
            Log.writeMessage("UserSkillController GetUserSkillById End");
            return userSkill;
        }



        [HttpPost]
        [ActionName("AddUserSkill")]
        public IHttpActionResult AddUserSkill(UserSkill userSkill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                userSkill.CreatedBy = "Admin";
                userSkill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                userSkill.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                userSkill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                result = userSkillDAL.AddUserSkill(userSkill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController AddUserSkill Error " + ex.Message);
            }
            return Ok(result);
        }

        [HttpPost]
        [ActionName("UpdateUserSkill")]
        public IHttpActionResult UpdateUserSkill(UserSkill userSkill)
        {
            var result = "";
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                userSkill.CreatedBy = "Admin";
                userSkill.CreatedDate = DateTime.Now.ToString("MM/dd/yyyy");
                userSkill.UpdatedBy = "Admin";
                //firstModel.Status = "Success";
                userSkill.UpdatedDate = DateTime.Now.ToString("MM/dd/yyyy");

                result = userSkillDAL.UpdateUserSkill(userSkill);



                if (result.ToString() == "0")
                {
                    return Ok("Failed");
                }

            }
            catch (Exception ex)
            {
                Log.writeMessage("UserSkillController AddUserSkill Error " + ex.Message);
            }
            return Ok(result);
        }





        // PUT: api/Address/5
        //[HttpPut]
        //[ActionName("UpdateFirstModel")]
        //public IHttpActionResult UpdateFirstModel(FirstModel firstModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            return BadRequest(ModelState);
        //        }
        //        var result = firstDAL.UpdateFirstModel(firstModel);




        //        if (result == "Success")
        //        {
        //            return Ok("Success");
        //        }
        //        else
        //        {
        //            return Ok("Failed");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.writeMessage("FirstController UpdateFirstModel Error " + ex.Message);
        //    }
        //    return Ok("Failed");
        //}

        //// DELETE: api/Address/5

        public IHttpActionResult DeleteUserSkill(int UserSkillId)
        {
            try
            {
                var result = userSkillDAL.DeleteUserSkill(UserSkillId);

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
                Log.writeMessage("UserSkillController DeleteUserSkill Error " + ex.Message);
            }
            return Ok("Failed");
        }


       
    }
}