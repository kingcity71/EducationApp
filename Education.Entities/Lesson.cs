using Education.Entities.Abstract;
using System;

namespace Education.Entities
{
    public class Lesson : Entity
    {
        public DateTime DateTime { get; set; }
        public Subject Subject { get; set; }
        public Tutor Tutor { get; set; }
        public Group Group { get; set; }
    }
}
