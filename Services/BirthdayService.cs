using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Сongratulator.Data;
using Сongratulator.Models;

namespace Сongratulator.Services
{
    public class BirthdayService
    {
        public Birthday Create(DateTime time, string firstName, string lastName, string? surname )
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                var sqlFormattedDate = time.ToUniversalTime();
                Birthday birthday = new Birthday { 
                    BirthDate = sqlFormattedDate, 
                    FirstName = firstName, 
                    LastName = lastName, 
                    Surname = surname 
                };
                
                db.Birthdays.Add( birthday );
                db.SaveChanges();

                return birthday;
            }    
        }
        
        public Birthday Read(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            { 
                
                Birthday line = db.Birthdays.Find(id);

                Birthday birthday = new Birthday
                {
                    Id = line.Id,
                    BirthDate = line.BirthDate.ToLocalTime(),
                    FirstName = line.FirstName,
                    LastName = line.LastName,
                    Surname = line.Surname
                };
                return birthday;
            }

        }
        
        public Birthday Update(int id, DateTime time, string firstName, string lastName, string? surname )
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Birthday birthday = new Birthday {
                    Id = id, 
                    BirthDate = time, 
                    FirstName = firstName, 
                    LastName = lastName, 
                    Surname = surname 
                };

                db.Birthdays.Update( birthday );
                db.SaveChanges();

                return birthday;
            }

        }

        public void Delete(int id) 
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Birthday birthday = new Birthday { Id = id };

                db.Birthdays.Remove( birthday );
                db.SaveChanges();

            }

        }


        
        


    }
}
