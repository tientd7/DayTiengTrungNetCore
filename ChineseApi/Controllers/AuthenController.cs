using Business.Interface;
using ChineseApi.Helper;
using DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChineseLearn.Controllers
{
    [Route("api/Authen")]
    [ApiController]
    [Authorize]
    public class AuthenController : ControllerBase
    {
        private readonly IAccountManager _account;
        private readonly TokenGenerator _token;
        public AuthenController(IAccountManager account, TokenGenerator token)
        {
            _account = account;
            _token = token;
        }
        //// GET: api/Authen
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Authen/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST: api/Authen
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Post([FromBody] LoginDto login)
        {
            CheckLoginDto rst = _account.CheckLogin(login);
            if (string.IsNullOrEmpty(rst.Message))
            {
                _token.TokenGenerate(rst);
                return Ok(rst);
            }
            return BadRequest(rst.Message);
        }

        //// PUT: api/Authen/5
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
