using Education.Entities.Abstract;

namespace Education.Entities
{
    public class LessonFile : Entity
    {
        public Lesson Lesson { get; set; }
        public string FilePath { get; set; }
    }
}
