using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Centuries_to_Minutes
{
    class Program
    {
        static void Main(string[] args)
        {
            double centuries = double.Parse(Console.ReadLine());
            double days = Math.Floor((centuries * 100) * 365.2422);
            double hours = days * 24;
            double minutes = hours * 60;
            Console.WriteLine($"{centuries} centuries = {centuries*100} years = {days} days = {hours} hours = {minutes} minutes");
        }
    }
}
