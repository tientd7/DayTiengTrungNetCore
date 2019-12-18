using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class FavoriteLessonDto
    {
        public string UserName { set; get; }
        public Paging Pager { set; get; }
        public ICollection<FavoriteLessonComponent> Components { set; get; }
    }
    public class FavoriteLessonComponent
    {
        //public string UserName { set; get; }
        public int LessonId { set; get; }
        public string LessonName { set; get; }
        public string LessonImg { set; get; }
        public bool IsLike { set; get; }
    }
}
