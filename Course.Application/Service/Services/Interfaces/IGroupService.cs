using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IGroupService
    {
        void Create(Group group);
        void Delete(int id);
        void Update(Group group);
        Group GetByName(string groupName);
        Group GetById(int id);
        List<Group> GetAll();
        List<Group> GetAllByTeacher(string teacher);
        List<Group> GetAllByRoom(string room);


    }
}
