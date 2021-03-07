using Education.Data;
using Education.Entities;
using Education.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Education.Services
{
    public class TutorService : ITutorService
    {
        private readonly EduContext _ctx;
        public TutorService(EduContext ctx)
        {
            _ctx = ctx;
        }
        public void Create(Tutor tutor)
        {
            tutor.Id = Guid.NewGuid();
            _ctx.Tutors.Add(tutor);
            _ctx.SaveChanges();
        }
    }
}
