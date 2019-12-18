using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interface;
using DTO;
using DAL.Interface;
using Entities;

namespace Business
{
    public class TopicBusiness : ITopicBusiness
    {
        IRepository<Topic> _repository;
        public TopicBusiness(IRepository<Topic> repository)
        {
            _repository = repository;
        }
        public TopicDTO GetAll(int pageIndex = 1, int pageSize = 20)
        {
            var query = _repository.GetMany(e => e.IsEnable).OrderBy(t => t.Name);

            TopicDTO rst = new TopicDTO();
            rst.Pager = new Paging(query.Count(), pageSize, pageIndex);
            rst.Components = (from s in query.Skip((pageIndex - 1) * pageSize).Take(pageSize)

                              select new TopicComponent()
                              {
                                  Id = s.Id,
                                  Name = s.Name,
                                  Description = s.Description,
                                  IsEnable = s.IsEnable,
                                  Vocabulary = s.Vocalbularies,
                                  Sentences = s.Content
                              }).ToList();

            return rst;
        }

        public TopicComponent GetById(int id)
        {
            var topic = _repository.FirstOrDefault(e => e.Id == id && e.IsEnable);
            if (topic == null)
                return null;
            else
                return new TopicComponent(topic);
        }
    }
}
