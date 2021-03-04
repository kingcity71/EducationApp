using Education.Entities;
using Education.Entities.Abstract;
using Education.Interfaces;
using Education.Models;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Education.Services
{
    public class UserService : IUserService
    {
        string secret = "40bc1ded2f324e8c8c4d0762c59e4751";
        private List<Student> _users = new List<Student>
        {
            new Student { Id = Guid.Parse("5f60d272-3516-426b-8cf9-07830ee65db8"), Email="a@a.a", Password = "12345678"}
        };

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Email == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse { Id = user.Id, Email = user.Email, Token = token };
        }
        public string GetAll() => "get all";
        public User GetUser(Guid id)
        {
            return _users.FirstOrDefault(u => u.Id == id);
        }
        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
