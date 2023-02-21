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
            consoleView.Message(" ");
            List<Birthday> birthdays = birthdayService.GetAllBirthdays();

            foreach(var record in birthdays)
            {
                consoleView.BirthdayOut(record);
            }
            consoleView.Message(" ");
        }

        public void ShowNear()
        {
            consoleView.Message(" ");
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
            consoleView.Message(" ");
        }
        
        public string UserChoise()
        {
            return consoleView.MessageRead("Введите действие \n" +
                "q - выйти из программы \n" +
                "1 - Отобразить все \n" +
                "2 - Отобразить ближайшие \n" +
                "3 - Добавить новую запись \n" +
                "4 - Редактировать запись \n" +
                "5 - Удалить запись \n");
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
        
        public void Editing()
        {

            
            int n = Convert.ToInt32(consoleView.MessageRead("Введите номер записи которую хотите изменить")); 
            
            Birthday birthday = birthdayService.ReadRecord(n);
            consoleView.BirthdayOut(birthday);
            Birthday newBirthday = consoleView.AddingBirthday(new Birthday());

            birthday = birthdayService.Update(birthday.Id, newBirthday.BirthDate, newBirthday.FirstName, newBirthday.LastName, newBirthday.Surname);

            consoleView.Message("Запись была обновлена");

        }

        public void Deleting()
        {
            int n = Convert.ToInt32(consoleView.MessageRead("Введите номер записи которую хотите удалить"));

            Birthday birthday = birthdayService.ReadRecord(n);
            consoleView.BirthdayOut(birthday);

            birthdayService.Delete(n);

            consoleView.Message("Запись была Удалена");

        }
    }
}
