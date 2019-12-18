using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Lesson
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public string VideoUrl { set; get; }
        public string Grama { set; get; }
        public bool IsVip { set; get; }
        [ForeignKey("Course")]
        public int CourseId { set; get; }
        public virtual Course Course { set; get; }
        public virtual ICollection<FavoriteLesson> FavoriteBys { set; get; } 
    }
}
