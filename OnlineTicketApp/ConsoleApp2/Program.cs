using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> vs = new List<string>()
            {
                "eli","veli","pirveli"
            };

           IEnumerable<string> result = vs.Where(x => x.Length > 3);

            vs.Add("sdfds");
            vs.Add("dsfdsfds");

            foreach (string item in result)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();

            
        }
    }
}
