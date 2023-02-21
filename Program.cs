using Сongratulator.Controllers;
using Сongratulator.Services;

namespace Сongratulator
{
    internal class Program
    {

        private static void Main(string[] args)
        {
            BirthdayController birthdayController = new();
            bool exit_flag = false;

            birthdayController.ShowNear();

            do
            {
                
                switch (birthdayController.UserChoise())
                {
                    case "q":
                        exit_flag = true;
                        break;
                    case "1":
                        birthdayController.ShowAll();
                        break;
                    case "2":
                        birthdayController.ShowNear();
                        break;
                    case "3":
                        birthdayController.Adding();
                        break;
                    case "4":
                        birthdayController.Editing();
                        break;
                    case "5":
                        birthdayController.Deleting();
                        break;
                    default:
                        Console.WriteLine("Такой команды не существует!\n");
                        break;
                }
            }
            while (!exit_flag);

            
        }
    }

}
