using Education.Data;
using Education.Entities;
using Education.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Education.Services
{
    public class LessonService : ILessonService
    {
        private readonly EduContext ctx;

        public LessonService(EduContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<Lesson> GetStudentWeekLessons(Guid userId, DateTime startDate)
        {
            var user = ctx.Students
                .Include(x => x.Group)
                .FirstOrDefault(x => x.Id == userId);
            
            var lessons = ctx.Lessons
                .Include(x => x.Subject)
                .Include(x => x.Tutor)
                .Include(x => x.Group)
                .Where(x => x.Group.Id == user.Group.Id && x.DateTime.Date >= startDate.Date && x.DateTime.Date < startDate.Date.AddDays(7))
                .ToList();
            
            return lessons;
        }
    }
}
