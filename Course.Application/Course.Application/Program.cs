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
            //case 6:
            //    Console.WriteLine("Enter Id:");
            //    string idStr = Console.ReadLine();
            //    int id = int.Parse(idStr);  
            //    studentController.GetById(id);
            //    break;
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
    ConsoleColor.Cyan.WriteConsole("Choose one operation : \n 1 - Create Group \n 2 - Update Group \n 3 - Delete Group \n 4 - Get All Groups \n 5 - Get Group By Name \n 6 - Get Student By Id");
}
