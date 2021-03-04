using System;

namespace Education.Entities.Abstract
{
    public abstract class Person : User
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
