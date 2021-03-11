using Education.Entities;
using Education.Entities.Abstract;
using Education.Interfaces;
using Education.Models;
using Education.WebApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

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
        [HttpGet("GetCurrentUser")]
        public IActionResult GetCurrentUser()
        {
            var user = (User)HttpContext.Items["User"];
            return Ok(user);
        }
    }
}
