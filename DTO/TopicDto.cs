using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TopicDTO
    {
        public Paging Pager { set; get; }
        public IEnumerable<TopicComponent> Components { set; get; }
    }
    public class TopicComponent
    {
        public TopicComponent()
        {

        }
        public TopicComponent(Topic topic)
        {
            Id = topic.Id;
            Name = topic.Name;
            Description = topic.Description;
            Sentences = topic.Content;
            IsEnable = topic.IsEnable;
            Vocabulary = topic.Vocalbularies;
        }
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Vocabulary { set; get; }
        public string Sentences { set; get; }
        public bool IsEnable { set; get; }
    }
}
