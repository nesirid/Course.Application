using Repository.Repositories.Interfaces;
using Service.Helpers.Extentions;
using Service.Services;
using Service.Services.Interfaces;
using Domain.Models;
using System.Threading.Tasks;

namespace Course.Application.Controllers
{
    internal class GroupController
    {
        private readonly IGroupService _groupService;
        public GroupController()
        {
            _groupService = new GroupService();
        }
        public void Create()
        {
            Console.WriteLine("Add Group name:");
        Name: string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name) || !name.All(c => char.IsLetter(c) || char.IsDigit(c)))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty or you used symbol!!!");
                goto Name;
            }
            Console.WriteLine("Add Teacher Name:");
        Teacher: string? teacher = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(teacher) || !teacher.All(char.IsLetter))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty or you used symbol!!!");
                goto Teacher;
            }
            Console.WriteLine("Add Room:");
        Room: string? room = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(room) || !room.All(c => char.IsLetter(c) || char.IsDigit(c)))
            {
                ConsoleColor.Red.WriteConsole("Input can't be empty or you used symbol!!!");
                goto Room;
            }
            try
            {
                _groupService.Create(new Group { Name = name, Teacher = teacher, Room = room });
                ConsoleColor.Green.WriteConsole("Data successfully added");
            }
            catch (Exception ex)
            {
                ConsoleColor.Red.WriteConsole(ex.Message);
                goto Name;
            }

        }
        public void GetAll()
        {
            var response = _groupService.GetAll();

            foreach (var item in response)
            {
                string data = $"Id: {item.Id}, Group name : {item.Name}, Group Teacher : {item.Teacher}, Group Room : {item.Room}";
                Console.WriteLine(data);
            }
        }
        public void Delete()
        {
            ConsoleColor.Cyan.WriteConsole("Enter Group id:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    Group group = _groupService.GetById(id);
                    if (group == null)
                    {
                        ConsoleColor.Red.WriteConsole("Not exist this group");
                        goto Id;
                    }
                    else
                    {
                        ConsoleColor.Yellow.WriteConsole("Are you sure you want to delete this group? (yes/no)");
                        string confirmation = Console.ReadLine().Trim().ToLower();

                        if (confirmation == "yes")
                        {
                            _groupService.Delete(id);
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
                    Group group = _groupService.GetById(id);
                    Console.WriteLine($"Id: {group.Id}, Group name : {group.Name}, Group Teacher : {group.Teacher}, Group Room : {group.Room}");
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
            ConsoleColor.Cyan.WriteConsole("Enter Group id, which you want to update:");
        Id: string idStr = Console.ReadLine();
            int id;
            bool isCorrectIdFormat = int.TryParse(idStr, out id);
            if (isCorrectIdFormat)
            {
                try
                {
                    Group existGroup = _groupService.GetById(id);
                    Console.WriteLine("Enter new Group name");
                    string groupName = Console.ReadLine();
                    Console.WriteLine("Enter new Group teacher");
                    string groupTeacher = Console.ReadLine();
                    Console.WriteLine("Enter new Group room");
                    string groupRoom = Console.ReadLine();

                    Group updatedGroup = new Group()
                    {
                        Name = groupName,
                        Teacher = groupTeacher,
                        Room = groupRoom
                    };
                    existGroup.Name = updatedGroup.Name;
                    existGroup.Teacher = updatedGroup.Teacher;
                    existGroup.Room = updatedGroup.Room;
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
        public void GetByName()
        {
            Console.WriteLine("Enter Group Name");
        GroupName: string groupName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(groupName))
            {
                Group group = _groupService.GetByName(groupName);
                if (group != null)
                {
                    Console.WriteLine($"Id: {group.Id}, Group name : {group.Name}, Group Teacher : {group.Teacher}, Group Room : {group.Room}");
                }
                else
                {
                    Console.WriteLine("Group Not found");
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Group name Not Found");
                goto GroupName;
            }
        }

        public void GetAllByTeacher()
        {
            Console.WriteLine("Enter Group Teacher");
        GroupTeacher: string groupTeacher = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(groupTeacher))
            {
                List<Group> groups = _groupService.GetAllByTeacher(groupTeacher);
                foreach (var item in groups)
                {
                    Console.WriteLine($"Id: {item.Id}, Group name : {item.Name}, Group Teacher : {item.Teacher}, Group Room : {item.Room}");
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Group name Not Found");
                goto GroupTeacher;
            }
        }
        public void GetAllByRoom()
        {
            Console.WriteLine("Enter Group Room");
        GroupRoom: string groupRoom = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(groupRoom))
            {
                List<Group> groups = _groupService.GetAllByRoom(groupRoom);
                foreach (var item in groups)
                {
                    Console.WriteLine($"Id: {item.Id}, Group name : {item.Name}, Group Teacher : {item.Teacher}, Group Room : {item.Room}");
                }
            }
            else
            {
                ConsoleColor.Red.WriteConsole("Group name Not Found");
                goto GroupRoom;
            }
        }

    }
}
