using Education.Entities.Abstract;
using Education.Entities.Enums;
using System;

namespace Education.Entities
{
    public class Request : Entity
    {
        public RequestStatus Status { get; set; }
        public DateTime DateTime{ get; set; }
        public User From { get; set; }
        public User To { get; set; }
        public string Text { get; set; }
        public string FilePath { get; set; }
    }
}
