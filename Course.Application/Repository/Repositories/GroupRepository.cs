using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System.Numerics;

namespace Repository.Repositories
{
    public class GroupRepository : BaseRepository<Group>, IGroupRepository
    {
        public List<Group> GetAllByRoom(string room)
        {
            return AppDbContext<Group>.datas.Where(m => m.Room == room).ToList();
        }

        public List<Group> GetAllByTeacher(string teacher)
        {
            return AppDbContext<Group>.datas.Where(m => m.Teacher == teacher).ToList();
        }

        public Group GetByName(string groupName)
        {
            return AppDbContext<Group>.datas.FirstOrDefault(m => m.Name == groupName);
        }
    }
}
