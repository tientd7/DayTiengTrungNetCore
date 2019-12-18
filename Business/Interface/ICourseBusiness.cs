using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ICourseBusiness
    {
        CourseDTO GetAll(int pageIndex = 1, int pageSize = 20);
        CourseComponent GetById(int id);
    }
}
