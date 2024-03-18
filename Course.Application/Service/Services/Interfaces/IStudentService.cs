using Domain.Models;

namespace Service.Services.Interfaces
{
    public interface IStudentService
    {
        void Create(Student student);
        void Delete(int id);
        void Update(Student student);
        Student GetByName(string studentName);
        Student GetById(int id);
        List<Student> GetByAge(int age);
        List<Student> GetByGroupId(int groupId);

    }
}
