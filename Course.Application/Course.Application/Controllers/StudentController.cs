using Service.Services.Interfaces;
using Service.Services;
using Domain.Models;
using Service.Helpers.Extentions;

namespace Course.Application.Controllers
{
    internal class StudentController
    {
        private readonly IStudentService _studentService;

        

        public StudentController()
        {
            _studentService = new StudentService();
        }

        public void Create()
        {
            Console.WriteLine("Add name:");
        Name: string? name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name) || !name.All(char.IsLetter))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty or you used symbol!!!");
                goto Name;
            }
            Console.WriteLine("Add Surname:");
        Surname: string? surname = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(surname) || !surname.All(char.IsLetter))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty or you used symbol!!!");
                goto Surname;
            }
            Console.WriteLine("Add Age:");
        Age: string? ageStr = Console.ReadLine();
            int age;
            bool isCorrectAgeFormat = int.TryParse(ageStr, out age);
            if (!isCorrectAgeFormat || age < 3 || age > 60)
            {
                ConsoleColor.Red.WriteConsole("Type of age is wrong or too young!!");
                goto Age;
            }
            Console.WriteLine("Add Room:");
        Group: string? group = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(group) || !group.All(c => char.IsLetter(c) || char.IsDigit(c)))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty or you used symbol!!!");
                goto Group;
            }
            try
            {
                _studentService.Create(new Student { Name = name, Surname = surname, Age = age, Group = group });
                ConsoleColor.Green.WriteConsole("Data successfully added");
                
                Console.WriteLine($" Name: {name}, Surname: {surname}, Age: {age}, Group: {group}");


            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }

        }
        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Enter Student id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    Student student = _studentService.GetById(id);
                    if (student == null)
                    {
                        ConsoleColor.Red.WriteConsole("Not exist this group");
                        goto Id;
                    }
                    else
                    {
                        ConsoleColor.Yellow.WriteConsole("Are you sure you want to delete this student? (yes/no)");
                        string confirmation = Console.ReadLine().Trim().ToLower();

                        if (confirmation == "yes")
                        {
                            _studentService.Delete(id);
                            ConsoleColor.Green.WriteConsole("Data successfully deleted");
                        }
                        else if (confirmation == "no")
                        {
                            ConsoleColor.Yellow.WriteConsole("Deletion canceled");
                        }
                        else
                        {
                            ConsoleColor.Red.WriteConsole("Invalid input. Please enter 'yes' or 'no'.");
                            goto Id;
                        }
                    }
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }
        public void Update()
        {
            ConsoleColor.Cyan.WriteConsole("Enter Student id, which you want to update:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    Student existStudent = _studentService.GetById(id);
                    Console.WriteLine("Enter new Student Name");
                    string studentName = Console.ReadLine();
                    Console.WriteLine("Enter new Student Surname");
                    string studentSurname = Console.ReadLine();
                    Console.WriteLine("Enter new Student Age");
                    Console.WriteLine("Enter new Student Group");
                    string studentGroup = Console.ReadLine();

                    string studentAgeStr = Console.ReadLine();
                    int studentAge;
                    bool isCorrectAge = int.TryParse(studentAgeStr, out studentAge);
                    while (!isCorrectAge)
                    {
                        ConsoleColor.Red.WriteConsole("Age type is wrong!!!");
                    }

                    Student updatedStudent = new Student()
                    {
                        Name = studentName,
                        Surname = studentSurname,
                        Age = studentAge,
                        Group = studentGroup
                    };
                    existStudent.Name = updatedStudent.Name;
                    existStudent.Surname = updatedStudent.Surname;
                    existStudent.Age = updatedStudent.Age;
                    existStudent.Group = updatedStudent.Group;
                    //_groupService.Update(group);
                    ConsoleColor.Green.WriteConsole("Data successfully updated");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }

        public void GetById()
        {
            ConsoleColor.Cyan.WriteConsole("Enter Group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    Student student = _studentService.GetById(id);
                    Console.WriteLine($"Id: {student.Id}, Student name : {student.Name}, Student Surname : {student.Surname}, Student Age : {student.Age} , Student Group : {student.Group}");
                }
                catch (Exception ex)
                {
                    ConsoleColor.Red.WriteConsole(ex.Message);
                    goto Id;
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Id format is wrong, please add again");
                goto Id;
            }
        }
        public void GetByName()
        {
            string name = Console.ReadLine();
            var student = _studentService.GetByName(name);
            string data = $"Id: {student.Id}, Student name : {student.Name}, Student Surname : {student.Surname}, Student Age : {student.Age}, Student Group : {student.Group}";
            Console.WriteLine(data);
        }
        public void GetByAge()
        {
            string ageStr = Console.ReadLine();
            int age = int.Parse(ageStr);
            var students = _studentService.GetByAge(age);
            foreach (var item in students)
            {
                Console.WriteLine($"Id: {item.Id}, Student name : {item.Name}, Student Surname : {item.Surname}, Student Age : {item.Age}, Student Group : {item.Group}");
            }
        }
        public void GetBySurnameOrName(string input)
        {
            List<Student> students = _studentService.GetBySurnameOrName(input);
            foreach (var student in students)
            {
                string data = $"Id: {student.Id}, Student name : {student.Name}, Student Surname : {student.Surname}, Student Age : {student.Age}, Student Group : {student.Group}";
                Console.WriteLine(data);
            }
        }
    }
}
