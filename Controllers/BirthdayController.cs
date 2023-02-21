using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сongratulator.Models;
using Сongratulator.Services;
using Сongratulator.Views;

namespace Сongratulator.Controllers
{
    internal class BirthdayController
    {
        private readonly BirthdayService birthdayService = new();
        private readonly ConsoleView consoleView = new();
        public void ShowAll()
        {
            List<Birthday> birthdays = birthdayService.GetAllBirthdays();

            foreach(var record in birthdays)
            {
                consoleView.BirthdayOut(record);
            }
        }

        public void ShowNear()
        {
          
            List<Birthday> birthdays = birthdayService.GetNearBirthdays();
            
            try
            {
                foreach (var record in birthdays)
                {
                    consoleView.BirthdayOut(record);
                }
            }
            catch(NullReferenceException) 
            {
                Console.WriteLine("Нет ближайших событий!");
            }
           
        }
        
        public string UserChoise()
        {
            return consoleView.MessageRead("Введите действие \n" +
                "q - выйти из программы \n" +
                "1 - Отобразить все \n" +
                "2 - Отобразить ближайшие \n" +
                "3 - Добавить новую запись \n"
                );
        }

        public void Adding() 
        {
            Birthday birthday = consoleView.AddingBirthday(new Birthday());
            birthdayService.Append(
                birthday.BirthDate, 
                birthday.FirstName, 
                birthday.LastName, 
                birthday.Surname);
            consoleView.Message("Вы успешно добавили новую запись!");
        }
        
    }
}
