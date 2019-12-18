using Business.Interface;
using DTO;
using System;
using DAL.Interface;
using Entities;
using System.Linq;
namespace Business
{
    public class FavoriteBusiness : IFavoriteBusiness
    {
        private readonly IRepository<FavoriteLesson> _favorite;
        private readonly IRepository<Lesson> _lesson;
        public FavoriteBusiness(IRepository<FavoriteLesson> favorite, IRepository<Lesson> lesson)
        {
            _favorite = favorite;
            _lesson = lesson;
        }
        public FavoriteLessonDto GetByUsername(string userName, int pageIndex = 1, int pageSize = 20)
        {
            var rst = new FavoriteLessonDto();
            var query = _favorite.GetMany(e => e.UserName.Equals(userName) && e.IsLike).OrderBy(e=>e.LessonID);
            rst.UserName = userName;
            rst.Pager = new Paging(query.Count(), pageSize, pageIndex);

            rst.Components = (from s in query.Skip((pageIndex - 1) * pageSize).Take(pageSize)
                              select new FavoriteLessonComponent
                              {
                                  LessonId = s.LessonID,
                                  LessonImg = s.Lesson.ImageUrl,
                                  LessonName = s.Lesson.Name,
                                  IsLike = s.IsLike
                              }).ToList(); ;
            return rst;
        }

        public string LikeToggle(string userName, int lessonId)
        {
            try
            {
                var obj = _favorite.FirstOrDefault(e => e.UserName.Equals(userName) && e.LessonID == lessonId);
                if (obj != null)
                {
                    //update item
                    obj.IsLike = !obj.IsLike;
                    _favorite.Update(obj);
                }
                else
                {
                    //check lesson exists
                    if (!_lesson.Exists(lessonId))
                        return "ERR: 404 NOT FOUND";

                    //Add new item
                    obj = new FavoriteLesson();
                    obj.IsLike = true;
                    obj.LessonID = lessonId;
                    obj.UserName = userName;

                    _favorite.Add(obj);
                }
                return "";
            }catch(Exception ex)
            {
                return ex.StackTrace;
            }
            
        }
    }
}
