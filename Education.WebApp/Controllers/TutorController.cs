using Education.Entities;
using Education.Entities.Abstract;
using Education.Interfaces;
using Education.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Education.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : Controller
    {
        private readonly ITutorService _tutorService;
        private readonly ILessonService lessonService;

        public TutorController(ITutorService tutorService, ILessonService lessonService)
        {
            _tutorService = tutorService;
            this.lessonService = lessonService;
        }

        [Authorize]
        [HttpGet("GetLessonsWeek")]
        public IEnumerable<Lesson> GetLessonsWeek(DateTime? start)
        {
            start = start ?? DateTime.Now;
            start = GetStart(start.Value);
            var user = (User)HttpContext.Items["User"];
            var lessons = lessonService.GetTutorWeekLessons(user.Id, start.Value);
            return lessons;
        }

        [Authorize]
        [HttpPost("Create")]
        public IActionResult Create(Tutor tutor)
        {
            try
            {
                _tutorService.Create(tutor);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            return Ok();
        }

        private DateTime GetStart(DateTime date)
        {
            while (date.DayOfWeek != DayOfWeek.Monday)
                date = date.AddDays(-1);
            return date;
        }
    }
}
