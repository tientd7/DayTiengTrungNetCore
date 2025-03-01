﻿using System;
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
    public class LessonsController : ControllerBase
    {
        private readonly ILessonBusiness _lesson;
        private string _userName = "";
        private string _vip = "";
        public LessonsController(ILessonBusiness lesson)
        {
            _lesson = lesson;
            
        }
        // GET: api/Topics
        [HttpGet]
        public LessonDTO Get(int pageIndex = 1, int pageSize = 20)
        {
            LessonDTO rst = new LessonDTO();
            try
            {
                rst = _lesson.GetAll(pageIndex, pageSize);
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            return rst;
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public LessonComponent Get(int id)
        {
            if (User != null)
            {
                try
                {
                    _userName = User.FindFirst(ClaimTypes.Name).Value;
                    _vip = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }
            LessonComponent rst = new LessonComponent();
            try
            {
                rst = _lesson.GetById(id, _userName, _vip);
            }
            catch (Exception ex) { Console.WriteLine(ex.StackTrace); }
            return rst;
        }

        //// POST: api/Lessons
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Lessons/5
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
