using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Tennis_Ranklist
{
    class Program
    {
        static void Main(string[] args)
        {
            int numTournaments = int.Parse(Console.ReadLine());
            int startingPoints = int.Parse(Console.ReadLine());
            string tournamentStage = "";
            double sumpoints = 0 + startingPoints;
            double wonpoints = 0;
            double wonTournaments = 0;

            int winerPoints = 2000;
            int finalistPoints = 1200;
            int semiFinalistPoints = 720;

            for (int i = 1; i <= numTournaments; i++)
            {
                tournamentStage = Console.ReadLine();
                switch (tournamentStage)
                {
                    case "W":
                        sumpoints = winerPoints + sumpoints;
                        wonpoints += winerPoints;
                        wonTournaments++;
                        break;
                    case "F":
                        wonpoints += finalistPoints;
                        sumpoints = finalistPoints + sumpoints; break;

                    case "SF":
                        sumpoints = semiFinalistPoints + sumpoints;
                        wonpoints += semiFinalistPoints;
                        break;
                }
            }
            Console.WriteLine($"Final points: {sumpoints}");
            Console.WriteLine($"Average points: {Math.Floor((wonpoints / numTournaments))}");
            Console.WriteLine($"{(wonTournaments / numTournaments) * 100:f2}%");
        }
    }
}
