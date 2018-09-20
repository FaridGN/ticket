using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

   public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte Age { get; set; }
        public string Email { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 435, 6, 7, 6587, 658, 65543 };

            List<Person> people = new List<Person>();

           var items = people.Where(x => x.Age > 60).Select(x => new { x.Age, x.Email });

            foreach (var item in items)
            {
                item.
            }

            numbers.Where(x => x > 6000);
        }
    }
}
