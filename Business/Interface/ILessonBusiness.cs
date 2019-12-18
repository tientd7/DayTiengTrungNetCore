using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ILessonBusiness
    {
        LessonDTO GetByCourse(int courseId, int pageIndex = 1, int pageSize = 20, string vip = "");
        LessonComponent GetById(int lessonId, string vip = "");
        LessonDTO GetAll(int pageIndex = 1, int pageSize = 20, string vip = "");
    }
}
