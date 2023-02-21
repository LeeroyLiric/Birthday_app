using Сongratulator.Services;

namespace Сongratulator
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            
            
            Console.WriteLine("Введите номер друга");
            int n = Convert.ToInt32(Console.ReadLine());
            var birth2 = birthdayService.Read(n);
            Console.WriteLine(birth2.Id.ToString() + birth2.FirstName.ToString() + birth2.BirthDate.ToString());
        }
    }

}
