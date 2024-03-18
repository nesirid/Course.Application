using Course.Application;
using Course.Application.Controllers;
using Service;
using Service.Helpers.Enums;
using Service.Helpers.Extentions;

GroupController groupController = new();
StudentController studentController = new();
while (true)
{
    GetMenues();
Operation: string? operationStr = Console.ReadLine();

    int operation;

    bool isCorrectOperationFormat = int.TryParse(operationStr, out operation);
    if (isCorrectOperationFormat)
    {
        switch (operation)
        {
            case 1:
                groupController.Create();
                break;
            case 2:
                groupController.Update();
                break;
            case 3:
                groupController.Delete();
                break;
            case 4:
                groupController.GetAll();
                break;
            case 5:
                groupController.GetByName();
                break;
            case 6:
                groupController.GetAllByRoom();
                break;
            case 7:
                groupController.GetAllByTeacher();
                break;
            case 8:
                groupController.GetById();
                break;
            case 11:
                studentController.Delete();
                break;
            case 10:
                studentController.Update();
                break;
            case 9:
                studentController.Create();
                break;
            case 12:
                studentController.GetByName();
                break;
            case 13:
                studentController.GetByAge();
                break;
            case 14:
                studentController.GetById();
                break;
            case 15:
                Console.WriteLine("Enter Name or Surname");
                string input =Console.ReadLine();
                studentController.GetBySurnameOrName(input);
                break;
            default:
                ConsoleColor.Red.WriteConsole("Operation is wrong, please choose again");
                goto Operation;
        }
    }
    else
    {
        ConsoleColor.Red.WriteConsole("Operation format is wrong, please add operation again");
        goto Operation;
    }
}

static void GetMenues()
{
    ConsoleColor.Cyan.WriteConsole("Choose one operation : \n 1 - Create Group \n 2 - Update Group \n 3 - Delete Group \n 4 - Get All Groups \n 5 - Get Group By Name \n 6 - Get Group By Room \n 7 - Get All Groups By Teacher \n 8 - Get All Groups By Id \n 9 - Create Student \n 10 - Update Student \n 11 - Delete Student \n 12 - Get Student By Name \n 13 - Get Student By Age \n 14 - Get Student By Id \n 15 - Get By Surname Or Name");
}
