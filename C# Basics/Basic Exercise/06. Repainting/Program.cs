using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Repainting
{
    class Program
    {
        static void Main(string[] args)
        {
            //input
            int nylonNeeded = int.Parse(Console.ReadLine()) + 2;
            int paintNeeded = int.Parse(Console.ReadLine());
            int thinnerNeeded = int.Parse(Console.ReadLine());
            int hoursNeeded = int.Parse(Console.ReadLine());

            //calculations
            double sumNylon = nylonNeeded * 1.50;
            double paintbonus = paintNeeded + (paintNeeded * 0.1);
            double sumPaint = paintbonus * 14.50;
            double sumThinner = thinnerNeeded * 5;
            double totallSumMaterials = sumNylon + sumPaint + sumThinner + 0.4;
            double sumWorkers = (totallSumMaterials * 0.3) * 8;
            double finallSum = totallSumMaterials + sumWorkers;

            Console.WriteLine(finallSum);
        }
    }
}
