using Domain.Models;
using Repository.Data;
using Repository.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        public List<Student> GetByAge(int age)
        {
            return AppDbContext<Student>.datas.Where(m => m.Age == age).ToList();
        }

        public List<Student> GetByGroupId(int groupId)
        {
            throw new NotImplementedException();
        }

        public Student GetByName(string studentName)
        {
            return AppDbContext<Student>.datas.FirstOrDefault(m => m.Name== studentName);
        }

        public List<Student> GetBySurnameOrName(string input)
        {
            return AppDbContext<Student>.datas.Where(s=>s.Name==input || s.Surname==input).ToList();   
        }
    }
}
