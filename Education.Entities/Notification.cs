using Education.Entities.Abstract;
using System;

namespace Education.Entities
{
    public class Notification : Entity
    {
        public User From { get; set; }
        public string To { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime Date { get; set; }
    }
}
