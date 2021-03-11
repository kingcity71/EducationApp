namespace Education.Entities.Abstract
{
    public abstract class User : Entity
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Discriminator { get; set; }
    }
}
