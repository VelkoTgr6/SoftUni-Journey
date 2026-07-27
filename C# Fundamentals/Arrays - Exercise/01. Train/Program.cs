using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Train
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            
            int sum = 0;

            int[] repeatPassangers = new int[n];
                
            for (int i = 0; i < n; i++)
            {
                int passangers =int.Parse(Console.ReadLine());
                repeatPassangers [i] = passangers;
                    
                sum += repeatPassangers[i];  
            }
            for (int i = 0; i <repeatPassangers.Length; i++)
            {
                Console.Write($"{ repeatPassangers[i]} " );
            }
            Console.WriteLine();
            Console.WriteLine(sum);
        }
    }
}
