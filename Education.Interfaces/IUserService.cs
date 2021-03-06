﻿using Education.Entities.Abstract;
using Education.Models;
using System;

namespace Education.Interfaces
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        User GetUser(Guid id);
    }
}
