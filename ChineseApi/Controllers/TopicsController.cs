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
    [Authorize]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicBusiness _topic;
        public TopicsController(ITopicBusiness topic)
        {
            _topic = topic;
        }
        // GET: api/Topics
        [HttpGet]
        public TopicDTO Get(int pageIndex = 1, int pageSize = 20)
        {
            TopicDTO rst = new TopicDTO();
            try
            {
                rst = _topic.GetAll(pageIndex, pageSize);
            }catch(Exception ex) { Console.WriteLine(ex.StackTrace); }
            return rst;
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public TopicComponent Get(int id)
        {
            TopicComponent rst = new TopicComponent();
            try
            {
                rst = _topic.GetById(id);
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            return rst;
        }

        // POST: api/Topics
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Topics/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
