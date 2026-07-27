using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Elevator
{
    class Program
    {
        static void Main(string[] args)
        {
            int nPeople = int.Parse(Console.ReadLine());
            int capacity = int.Parse(Console.ReadLine());

            int courses =(int)Math.Ceiling((double)nPeople / capacity);
            
                Console.WriteLine(courses);



        }
    }
}
