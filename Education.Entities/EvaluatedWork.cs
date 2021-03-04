using Education.Entities.Abstract;
using Education.Entities.Enums;

namespace Education.Entities
{
    //оцениваемая работа - домашка, контрольные, самостоятельные
    public class EvaluatedWork : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public WorkType WorkType { get; set; }
        public Lesson Lesson { get; set; }
    }
}
