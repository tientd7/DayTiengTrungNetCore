using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Interface
{
    public interface IFavoriteBusiness
    {
        string LikeToggle(string userName, int lessonId);
        FavoriteLessonDto GetByUsername(string userName,int pageIndex = 1, int pageSize = 20);
    }
}
