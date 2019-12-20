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
    [Authorize]
    public class FavoriteController : ControllerBase
    {
        private readonly IFavoriteBusiness _favorite;
        private string _userName = "";
        public FavoriteController(IFavoriteBusiness favorite)
        {
            _favorite = favorite;
            
        }
        // GET: api/Favorite
        [HttpGet]
        public FavoriteLessonDto Get(int pageIndex =1, int pageSize = 20)
        {
            if (User != null)
            {
                try
                {
                    _userName = User.FindFirst(ClaimTypes.Name).Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }
            return _favorite.GetByUsername(_userName,pageIndex,pageSize);
        }

        // GET: api/Favorite/5
        /// <summary>
        /// Method like/unlike
        /// </summary>
        /// <param name="id">lessonId</param>
        /// <returns>normaly is null, exception is a message!!</returns>
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            if (User != null)
            {
                try
                {
                    _userName = User.FindFirst(ClaimTypes.Name).Value;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.StackTrace);
                }

            }
            return _favorite.LikeToggle(_userName,id);
        }

        // POST: api/Favorite
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Favorite/5
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
