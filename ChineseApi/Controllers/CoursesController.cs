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
    public class CoursesController : ControllerBase
    {
        private readonly ICourseBusiness _course;
        private readonly ILessonBusiness _lesson;
        public CoursesController(ICourseBusiness course, ILessonBusiness lesson)
        {
            _course = course;
            _lesson = lesson;
        }
        // GET: api/Topics
        [HttpGet]
        public CourseDTO Get(int pageIndex = 1, int pageSize = 20)
        {
            CourseDTO rst = new CourseDTO();
            try
            {
                rst = _course.GetAll(pageIndex, pageSize);
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            return rst;
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public LessonDTO Get(int id, int pageIndex = 1, int pageSize = 20)
        {
            LessonDTO rst = new LessonDTO();
            try
            {
                rst = _lesson.GetByCourse(id, pageIndex, pageSize);
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            return rst;
        }

        // POST: api/Courses
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Courses/5
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
