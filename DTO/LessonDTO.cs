using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class LessonDTO
    {
        public LessonDTO()
        {
            Pager = new Paging();
            Course = new CourseComponent();
            Components = new List<LessonComponent>();
        }
        public Paging Pager { set; get; }
        public CourseComponent Course { set; get; }
        public IEnumerable<LessonComponent> Components { set; get; }
    }
    public class LessonComponent
    {
        public LessonComponent() { }
        public LessonComponent(Lesson lesson, string courseName)
        {
            Id = lesson.Id;
            Name = lesson.Name;
            Description = lesson.Description;
            ImageUrl = lesson.ImageUrl;
            VideoUrl = lesson.VideoUrl;
            Grama = lesson.Grama;
            isVip = lesson.isVip;
            CourseId = lesson.CourseId;
            CourseName = courseName;
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public string VideoUrl { set; get; }
        public string Grama { set; get; }
        public bool isVip { set; get; }
        public int CourseId { set; get; }
        public string CourseName { set; get; }
    }
}
