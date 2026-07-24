using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.Oscars
{
    class Program
    {
        static void Main(string[] args)
        {
            string nameActor = Console.ReadLine();
            double pointsOfAcademi = double.Parse(Console.ReadLine());
            int numJury = int.Parse(Console.ReadLine());
            string nameJury = "";
            double pointsOfJury = 0;
            int lenght = 0;
            //  double firstSumPoints = 0;
            //double totalSumPoints = firstSumPoints + ((lenght * pointsOfJury) / 2);

            for (int i = 1; i <= numJury; i++)
            {
                nameJury = Console.ReadLine();
                pointsOfJury = double.Parse(Console.ReadLine());
                lenght = nameJury.Length;
                pointsOfAcademi += ((lenght * pointsOfJury) / 2);
                if (pointsOfAcademi > 1250.5)
                    break;
                //totalSumPoints+=firstSumPoints+((lenght* pointsOfJury) / 2);
                //double points = ((lenght * pointsOfJury) / 2);
            }


            if (pointsOfAcademi < 1250.5)
            {
                Console.WriteLine($"Sorry, {nameActor} you need {1250.5 - pointsOfAcademi:f1} more!");
            }
            else
            {
                Console.WriteLine($"Congratulations, {nameActor} got a nominee for leading role with {pointsOfAcademi:f1}!");
            }
        }
    }
}
