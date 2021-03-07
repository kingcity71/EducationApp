using Education.Data;
using Education.Entities;
using Education.Entities.Abstract;
using Education.Interfaces;
using Education.Models;
using Microsoft.EntityFrameworkCore;
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
        private readonly EduContext _ctx;
        string secret = "40bc1ded2f324e8c8c4d0762c59e4751";

        public UserService(EduContext ctx)
        {
            _ctx = ctx;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            Func<User, bool> func = x => x.Email.ToLower() == model.Username.ToLower() && x.Password == model.Password;
            User user = _ctx.Admins.AsNoTracking().FirstOrDefault(func);
            user = user != null ? user : _ctx.Students.AsNoTracking().FirstOrDefault(func);
            user = user != null ? user : _ctx.Tutors.AsNoTracking().FirstOrDefault(func);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse { Id = user.Id, Email = user.Email, Token = token };
        }
        public User GetUser(Guid id)
        {
            Func<User, bool> func = x => x.Id == id;
            User user = _ctx.Admins.AsNoTracking().FirstOrDefault(func);
            user = user != null ? user : _ctx.Students.AsNoTracking().FirstOrDefault(func);
            user = user != null ? user : _ctx.Tutors.AsNoTracking().FirstOrDefault(func);
            return user;
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
