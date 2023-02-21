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
        public void Append(DateTime time, string firstName, string lastName, string? surname )
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
            }    
        }
        
        public Birthday ReadRecord(int id)
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

        public List<Birthday> GetAllBirthdays()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Birthday> lines = db.Birthdays.ToList();
                foreach (var line in lines)
                {
                    line.BirthDate = line.BirthDate.ToLocalTime();
                }
                return lines;
            }
        }

        public List<Birthday> GetNearBirthdays()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Birthday> lines = new();
                foreach (var record in db.Birthdays)
                {
                    if (Math.Abs(record.BirthDate.ToLocalTime().DayOfYear - DateTime.Now.DayOfYear) <= 7)
                    {

                        lines.Add(new Birthday
                        {
                            Id = record.Id,
                            BirthDate = record.BirthDate.ToLocalTime(),
                            FirstName = record.FirstName,
                            LastName = record.LastName,
                            Surname = record.Surname
                        });
                    }
                        
                }
                return lines;
            }
        }
        
        public Birthday Update(int id, DateTime time, string firstName, string lastName, string? surname )
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Birthday birthday = new Birthday {
                    Id = id, 
                    BirthDate = time.ToUniversalTime(), 
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
