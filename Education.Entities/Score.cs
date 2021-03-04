using Education.Entities.Abstract;
using System;

namespace Education.Entities
{
    public class Score : Entity
    {
        public Student Student { get; set; }
        public Tutor Tutor { get; set; }
        public double Points { get; set; }
        public DateTime Date{ get; set; }
        public EvaluatedWorkAnswer MyProperty { get; set; }
    }
}
