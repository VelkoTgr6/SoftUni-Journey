using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.The_Angry_Cat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> priceRating = Console.ReadLine()
                .Split(',')
                .Select(int.Parse)
                .ToList();
            int entryPoint = int.Parse(Console.ReadLine());
            string type = Console.ReadLine();
            int originalRatingCount = priceRating.Count;
            int cheapSumLeft = 0;
            int cheapSumRight = 0;
            int expensiveSumLeft = 0;
            int expensiveSumRight = 0;

            for (int i = 0; i < priceRating.Count; i++)
            {

                switch (type)
                {
                    case "cheap":
                        if (priceRating[i] < entryPoint)
                        {
                            if (i < entryPoint)
                                cheapSumLeft += priceRating[i];
                            if (i > entryPoint)
                                cheapSumRight += priceRating[i];
                        }
                        break;

                    case "expensive":
                        if (priceRating[i] >= entryPoint)
                        {
                            if (i < entryPoint)
                                expensiveSumLeft += priceRating[i];
                            if (i > entryPoint)
                                expensiveSumRight += priceRating[i];
                        }
                        break;
                }

            }
            if (type == "cheap")
            {
                if (cheapSumLeft >= cheapSumRight)
                {
                    Console.WriteLine($"left - {cheapSumLeft}");
                }
                else
                {
                    Console.WriteLine($"right - {cheapSumRight}");
                }
            }
            if (type == "expensive")
            {
                if (expensiveSumLeft >= expensiveSumRight)
                {
                    Console.WriteLine($"left - {expensiveSumLeft}");
                }
                else
                {
                    Console.WriteLine($"right - {expensiveSumRight}");
                }


            }
        }
    }
}
