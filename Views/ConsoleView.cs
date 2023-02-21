using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сongratulator.Models;
using Сongratulator.Services;

namespace Сongratulator.Views
{
    internal class ConsoleView
    {
        public void BirthdayOut (Birthday birthday ) 
        {
            Console.WriteLine(
                birthday.Id.ToString() + " " +
                birthday.BirthDate.ToShortDateString() + " " +
                birthday.FirstName.ToString() + " " +
                birthday.LastName.ToString() + " " +
                birthday.Surname.ToString()
                );
        }

        public string MessageRead(string text)
        {
            Console.WriteLine(text);
            return Console.ReadLine();
        }

        public void Message(string text)
        {
            Console.WriteLine(text);
        }

        public Birthday AddingBirthday(Birthday birthday)
        {
            Console.WriteLine();
            
            Console.WriteLine("Введите новую дату");
            birthday.BirthDate = Convert.ToDateTime(Console.ReadLine());
            
            Console.WriteLine("Введите новое имя");
            birthday.FirstName = Console.ReadLine();
            
            Console.WriteLine("Введите новую фамилию");
            birthday.LastName = Console.ReadLine();

            Console.WriteLine("Введите новое отчество");
            birthday.Surname = Console.ReadLine();

            Console.WriteLine();

            return birthday;
        }
    }
}
