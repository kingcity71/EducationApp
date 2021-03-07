using Education.Entities;
using Education.Interfaces;
using Education.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Education.WebApp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TutorController : Controller
    {
        private readonly ITutorService _tutorService;

        public TutorController(ITutorService tutorService)
        {
            _tutorService = tutorService;
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
    }
}
