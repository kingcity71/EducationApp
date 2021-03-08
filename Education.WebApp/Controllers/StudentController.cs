using Education.Entities;
using Education.Entities.Abstract;
using Education.Interfaces;
using Education.WebApp.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Education.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly IStudentService _studentService;
        private readonly ILessonService lessonService;

        public StudentController(IStudentService studentService, ILessonService lessonService)
        {
            _studentService = studentService;
            this.lessonService = lessonService;
        }
        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create(Student student)
        {
            try
            {
                _studentService.Create(student);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }
    
        [Authorize]
        [HttpGet("GetLessonsWeek")]
        public IEnumerable<Lesson> GetLessonsWeek(DateTime? start)
        {
            start = start ?? DateTime.Now;
            start = GetStart(start.Value);
            var user = (User)HttpContext.Items["User"];
            var lessons = lessonService.GetStudentWeekLessons(user.Id, start.Value);
            return lessons;
        }

        private DateTime GetStart(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(-1);
            return date;
        }

    }
}
