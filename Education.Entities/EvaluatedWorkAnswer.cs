using Education.Entities.Abstract;

namespace Education.Entities
{
    public class EvaluatedWorkAnswer : Entity
    {
        public EvaluatedWork Work { get; set; }
        public Student Student { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
    }
}
