using Business.Interface;
using DAL.Interface;
using DTO;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class CourseBusiness : ICourseBusiness
    {
        private readonly IRepository<Course> _repository;
        public CourseBusiness(IRepository<Course> repository)
        {
            _repository = repository;
        }
        public CourseDTO GetAll(int pageIndex = 1, int pageSize = 20)
        {
            var query = _repository.GetMany(e => e.IsEnable).OrderBy(t=>t.Name);

            CourseDTO rst = new CourseDTO();
            rst.Pager = new Paging(query.Count(), pageSize, pageIndex);
            rst.Components = (from s in query.Skip((pageIndex-1)*pageSize).Take(pageSize)
                              
                              select new CourseComponent()
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                                  Description = s.Description,
                                  ImageUrl = s.ImageUrl,
                                  IsEnable = s.IsEnable
                              }).ToList();

            return rst;
        }

        public CourseComponent GetById(int id)
        {
            var course = _repository.FirstOrDefault(e => e.Id == id && e.IsEnable);
            if (course == null)
                return null;
            else
            return new CourseComponent(course);
            
        }
    }
}
