using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Topic
    {
        [Key]
        public int Id { set; get; }
        public string Name { set; get; }
        public string Description { set; get; }
        [Display(Name= "Vocabulary")]
        public string Vocalbularies { set; get; }
        [Display(Name="Sentences")]
        public string Content { set; get; }
        public bool IsEnable { set; get; }
    }
}
