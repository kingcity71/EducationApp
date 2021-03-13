using Education.Entities;
using System;
using System.Collections.Generic;

namespace Education.Interfaces
{
    public interface ILessonService
    {
        IEnumerable<Lesson> GetStudentWeekLessons(Guid userId, DateTime startDate);
        IEnumerable<Lesson> GetTutorWeekLessons(Guid userId, DateTime startDate);
    }
}
