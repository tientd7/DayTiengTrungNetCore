using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Course
    {
        [Key]
        public int Id { set; get; }
        [Display(Name ="Course Name")]
        public string Name { set; get; }
        public string Description { set; get; }
        public string ImageUrl { set; get; }
        public bool IsEnable { set; get; }
        public virtual ICollection<Lesson> Lessons { set; get; }
    }
}
