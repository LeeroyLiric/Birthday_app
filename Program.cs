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

            do
            {
                birthdayController.ShowNear();
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
                    default:
                        Console.WriteLine("Такой команды не существует!\n");
                        break;
                }
            }
            while (!exit_flag);

            /*
            Console.WriteLine("Введите номер друга");
            int n = Convert.ToInt32(Console.ReadLine());
            var birth2 = birthdayService.Read(n);
            Console.WriteLine(birth2.Id.ToString() + birth2.FirstName.ToString() + birth2.BirthDate.ToString());
            */
        }
    }

}
