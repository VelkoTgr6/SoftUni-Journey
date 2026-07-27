using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Array_Rotation
{
    class Program
    {
        static void Main(string[] args)
        {
            string [] array = Console.ReadLine()
                .Split()
                .ToArray();
            int n = int.Parse(Console.ReadLine());
            string[] tempArr =new string [array.Length+1];

            for (int j = 0; j < n; j++)
            {
                var temp = array[0];
                for (var i = 0; i < array.Length - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[array.Length - 1] = temp;
            }
            Console.WriteLine("{0}", string.Join(" ", array));
            
        }
    }
}
