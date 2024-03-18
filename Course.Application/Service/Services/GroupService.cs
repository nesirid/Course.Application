using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _groupRepo;
        private int count = 1;
        public GroupService()
        {
            _groupRepo= new GroupRepository();
        }
        public void Create(Group group)
        {
            if(group == null) throw new ArgumentNullException();
            group.Id= count;
            _groupRepo.Create(group);
            count++;
        }

        public void Delete(int id)
        {
            if(id == null) throw new NotImplementedException();
            Group group = _groupRepo.GetById((int)id);
            _groupRepo.Delete(group);

        }

        public List<Group> GetAll()
        {
            return _groupRepo.GetAll();
        }

        public List<Group> GetAllByRoom(string room)
        {
            if(room ==null) throw new ArgumentNullException();
            List<Group> list = _groupRepo.GetAllByRoom(room);
            return list;
        }

        public List<Group> GetAllByTeacher(string teacher)
        {
            if (teacher == null) throw new ArgumentNullException();
            List<Group> list = _groupRepo.GetAllByTeacher(teacher);
            return list;
        }

        public Group GetById(int id)
        {
            if (id == null) throw new NotImplementedException();
            Group group = _groupRepo.GetById((int)id);
            return group;
        }

        public Group GetByName(string groupName)
        {
            if (groupName == null) throw new ArgumentNullException();
            Group group = _groupRepo.GetByName(groupName);
            return group;
        }

        public void Update(Group group)
        {
            if(group==null) throw new NotImplementedException();
            _groupRepo.Edit(group);

        }
    }
}
