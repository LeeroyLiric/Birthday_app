using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сongratulator.Services;

namespace Сongratulator.Views
{
    internal static class ConsoleView
    {
         static void AddingBirthday()
        {
            BirthdayService birthdayService = new BirthdayService();
            Console.WriteLine("Введите дату");
            DateTime date = Convert.ToDateTime(Console.ReadLine());
            Console.WriteLine("Введите имя");
            string name = Console.ReadLine();
            Console.WriteLine("Введите фамилию");
            string lastName = Console.ReadLine();
            Console.WriteLine("Введите отчество");
            string? surname = Console.ReadLine();

            var birthday = birthdayService.Create(date, name, lastName, surname);
        }
    }
}
