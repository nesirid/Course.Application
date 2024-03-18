using Domain.Models;
using Repository.Repositories;
using Repository.Repositories.Interfaces;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepo;
        private int count = 1;
        public StudentService()
        {
            _studentRepo = new StudentRepository(); 
        }
        public void Create(Student student)
        {
            if (student == null) throw new ArgumentNullException();
            student.Id = count;
            _studentRepo.Create(student);
            count++;
        }

        public void Delete(int id)
        {
            if (id == null) throw new NotImplementedException();
            Student student = _studentRepo.GetById((int)id);
            _studentRepo.Delete(student);
        }

        public List<Student> GetByAge(int age)
        {
            if (age == null) throw new NotImplementedException();
            List<Student> students= _studentRepo.GetByAge(age);
            return students;
        }

        public List<Student> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetById(int id)
        {
            if (id == null) throw new NotImplementedException();
            return _studentRepo.GetById((int)id);
            
        }

        public Student GetByName(string studentName)
        {
            if (studentName == null) throw new NotImplementedException();
            Student student = _studentRepo.GetByName(studentName);
            return student;
        }

        public List<Student> GetBySurnameOrName(string input)
        {

            if(input==null) throw new NotImplementedException();
            List<Student> students = _studentRepo.GetBySurnameOrName(input);
            return students;
        }

        public void Update(Student student)
        {
            if (student == null) throw new NotImplementedException();
            _studentRepo.Edit(student);
        }
    }
}
