using Education.Data;
using Education.Entities;
using Education.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Education.Services
{
    public class StudentService : IStudentService
    {
        private readonly EduContext _ctx;
        public StudentService(EduContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(Student student)
        {
            student.Group = _ctx.Groups.FirstOrDefault(x => x.Name.ToLower() == student.Group.Name.ToLower());
            student.Id = Guid.NewGuid();
            _ctx.Students.Add(student);
            _ctx.SaveChanges();
        }
    }
}
