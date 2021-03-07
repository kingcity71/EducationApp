using Education.Entities;
using System.Collections.Generic;

namespace Education.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<Group> GetAll();
    }
}
