using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class FavoriteLesson
    {
        [Key]
        public int Id { set; get; }
        public string UserName { set; get; }
        [ForeignKey("Lesson")]
        public int LessonID { set; get; }
        public bool IsLike { set; get; }
        public virtual Lesson Lesson { set; get; }
    }
}
