using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Vacation_Books_List
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int numberSheets = int.Parse(Console.ReadLine());
            int sheetsForHour = int.Parse(Console.ReadLine());
            int daysForReading = int.Parse(Console.ReadLine());

            //calculations
            int sumSheets = numberSheets / sheetsForHour;
            int hoursNeeded = sumSheets / daysForReading;

            Console.WriteLine(hoursNeeded);
        }
    }
}
