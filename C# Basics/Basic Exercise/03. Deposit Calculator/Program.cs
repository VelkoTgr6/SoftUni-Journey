using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Deposit_Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            double depositSum = double.Parse(Console.ReadLine());
            int depositMonths = int.Parse(Console.ReadLine());
            double annualPercenRate = double.Parse(Console.ReadLine());
            //calculations
            double acuuredInterest = depositSum * annualPercenRate / 100;
            double MonthlyInterest = acuuredInterest / 12;
            double finallSum = depositSum + (depositMonths * MonthlyInterest);
        }
    }
}
