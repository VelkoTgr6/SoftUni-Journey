using System;

namespace _01._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string input;
            string reversed = "";
            while ((input=Console.ReadLine())!="end")
            {
                for (int i = input.Length-1; i >= 0; i--)
                {
                    reversed += input[i];
                }
                Console.WriteLine($"{input} = {reversed}");
                reversed = "";
            }
        }
    }
}
