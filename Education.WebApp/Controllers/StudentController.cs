using Education.Entities;
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

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
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
    }
}
