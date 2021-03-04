using Education.Entities;
using Education.Interfaces;
using Education.Models;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IStudentService _studentService;

        public UserController(IUserService userService, IStudentService studentService)
        {
            _userService = userService;
            _studentService = studentService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        [Authorize]
        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Authorize]
        [HttpPost("RegisterStudent")]
        public IActionResult Register(Student student)
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
        [HttpPost("RegisterTutor")]
        public IActionResult Register(Tutor tutor)
        {
            return Ok();
        }
    }
}
