using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Calculations
{
    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            int number1 = int.Parse(Console.ReadLine());
            int number2 = int.Parse(Console.ReadLine());
            

            Add( command, number1, number2);
            Multiply( command, number1, number2);
            Divide( command, number1, number2);
            Subtract( command, number1, number2);

        }
        static void Add(string command,int number1,int number2)
        {
            if(command== "add")
            Console.WriteLine(number1+number2);
        }
        static void Multiply(string command,int number1, int number2)
        {
            if(command=="multiply")
            Console.WriteLine(number1*number2);
        }
        static void Subtract(string command, int number1, int number2)
        {
            if(command=="subtract")
            Console.WriteLine(number1-number2);
        }
        static void Divide(string command, int number1, int number2)
        {
            if(command=="divide")
            Console.WriteLine(number1/number2);
        }
    }
}
