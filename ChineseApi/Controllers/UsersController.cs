using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Business.Interface;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChineseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class UsersController : ControllerBase
    {
        private readonly IAccountManager _account;
        public UsersController(IAccountManager account)
        {
            _account = account;
        }
        // GET: api/Users
        [HttpPost]
        [Route("ResetPassword")]
        public IActionResult Post([FromBody]ResetPassword reset)
        {
            string msg = "";
            try
            {
                msg = _account.ResetPassword(reset);
                return Ok(new Response("200", msg));
            }catch(Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine(ex.Message);
                return BadRequest(new Response("400", ex.Message));
            }
        }

        //// GET: api/Users/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Users
        /// <summary>
        /// Signup a new account
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Register")]
        public IActionResult Post([FromBody] RegisterDto register)
        {
            if (!register.Password.Equals(register.ConfirmPassword))
                return BadRequest(new Response("400", "Confirmed password is not correct!"));
            try
            {
                string msg = _account.CreateUser(register);
                return Ok(new Response("200", msg));
            }catch(Exception ex)
            {
                return BadRequest(new Response("400", ex.Message));
            }
        }

        //// PUT: api/Users/5
        ///// <summary>
        ///// Changepassword
        ///// </summary>
        ///// <param name="id">UserName</param>
        ///// <param name="changePass">Json string</param>
        //[HttpPut("{id}")]
        //[Authorize]
        //public IActionResult Put(string id, [FromBody] ChangePassDto changePass)
        //{
        //    string userName = "";
        //    if (User != null)
        //    {
        //        try
        //        {
        //            userName = User.FindFirst(ClaimTypes.Name).Value;
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine(ex.StackTrace);
        //            Console.WriteLine(new Response("401", "Error: Unauthorized"));
        //            return Unauthorized(new Response("401", "Error: Unauthorized"));
        //        }

        //    }
        //    try
        //    {
        //        string mess = _account.ChangePassword(userName, changePass);
        //        return Ok(new Response("200", mess));
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(new Response("400", ex.Message));
        //    }
        //}




        // POST: api/Users/ChangePass
        /// <summary>
        /// Changepassword
        /// </summary>
        /// <param name="changePass">Json string</param>
        [HttpPost]
        [Route("ChangePass")]
        [Authorize]
        public IActionResult Post([FromBody] ChangePassDto changePass)
        {
            string userName = "";
            if (User != null)
            {
                try
                {
                    userName = User.FindFirst(ClaimTypes.Name).Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                    Console.WriteLine(new Response("401", "Error: Unauthorized"));
                    return Unauthorized(new Response("401", "Error: Unauthorized"));
                }

            }
            try
            {
                string mess = _account.ChangePassword(userName, changePass);
                return Ok(new Response("200", mess));
            }catch(Exception ex)
            {
                return BadRequest(new Response("400", ex.Message));
            }
        }

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
