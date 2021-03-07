using Education.Data;
using Education.Entities;
using Education.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Education.Services
{
    public class GroupService : IGroupService
    {
        private readonly EduContext ctx;

        public GroupService(EduContext ctx)
        {
            this.ctx = ctx;
        }
        public IEnumerable<Group> GetAll()
        => ctx.Groups.AsNoTracking().ToList();
    }
}
