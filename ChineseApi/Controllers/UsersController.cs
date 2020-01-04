using System;
using System.Collections.Generic;
using System.Linq;
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
        //// GET: api/Users
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Users/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Users
        [HttpPost]
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
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
