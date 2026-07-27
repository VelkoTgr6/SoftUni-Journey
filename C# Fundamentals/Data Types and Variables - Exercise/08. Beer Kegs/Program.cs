using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.Beer_Kegs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string theBiggestName = "";
            double  theBiggestCalc= float.MinValue;


            for (int i = 1; i <=n; i++)
            {
                string model = Console.ReadLine();
                float radius = float.Parse(Console.ReadLine());
                float height = float.Parse(Console.ReadLine());
                double formula = Math.PI * Math.Pow(2, radius) * height;
                if (formula > theBiggestCalc)
                {
                    theBiggestCalc = formula;
                    theBiggestName = model;
                }

            }
            Console.WriteLine(theBiggestName);


        }
    }
}
