using Education.Entities.Abstract;

namespace Education.Entities
{
    public class Student : Person
    {
        public Group Group { get; set; }
    }
}
