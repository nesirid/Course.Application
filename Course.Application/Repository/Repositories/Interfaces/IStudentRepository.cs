using Domain.Models;

namespace Repository.Repositories.Interfaces
{
    public interface IStudentRepository : IBaseRepository<Student>
    {
        List<Student> GetByAge(int age);
        List<Student> GetByGroupId(int groupId);
        Student GetByName(string studentName);
    }
}
