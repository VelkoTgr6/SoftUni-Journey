using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.Greater_of_Two_Values
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            string a = Console.ReadLine();
            string b = Console.ReadLine();
            Console.WriteLine(GetMax(type, a, b));
        }
        static string GetMax(string type, string a, string b)
        {
            string result = "";

            switch (type)
            {
                case "int":
                    result = (Math.Max(int.Parse(a), int.Parse(b)).ToString());
                    break;
                case "char":
                case "string":
                    int comapre = a.CompareTo(b);
                    if (comapre > 0)
                        result = a;
                    else
                        result = b;
                    break;
            }
            return result;

        }
        
    }
}
