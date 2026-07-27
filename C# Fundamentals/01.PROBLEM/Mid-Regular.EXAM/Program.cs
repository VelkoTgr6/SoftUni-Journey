using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mid_Regular.EXAM
{
    class Program
    {
        static void Main(string[] args)
        {
            int biscutsPerDay = int.Parse(Console.ReadLine());
            int workersCount = int.Parse(Console.ReadLine());
            int otherFactory30days = int.Parse(Console.ReadLine());
            double sumBiscuits = 0;
            int PerDayPerWorker = biscutsPerDay * workersCount;

            for (int i = 1; i <=30; i++)
            {
                if (i % 3 == 0)
                {
                    sumBiscuits += PerDayPerWorker *0.75;
                    sumBiscuits = Math.Floor(sumBiscuits);
                }
                else
                    sumBiscuits += PerDayPerWorker;

            }
            double differrence = Math.Abs(sumBiscuits - otherFactory30days);
            Console.WriteLine($"You have produced {(int)sumBiscuits} biscuits for the past month.") ;

            if (sumBiscuits > otherFactory30days)
                Console.WriteLine($"You produce {(differrence/otherFactory30days*100):f2} percent more biscuits.");
            else
                Console.WriteLine($"You produce {(differrence / otherFactory30days * 100):f2} percent less biscuits.");
        }
    }
}
