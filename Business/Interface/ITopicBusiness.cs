using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interface
{
    public interface ITopicBusiness
    {
        TopicDTO GetAll(int pageIndex = 1, int pageSize = 20);
        TopicComponent GetById(int id);
    }
}
