using System.Diagnostics;
using System.Xml.Linq;

namespace _4._Sum_of_Integers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            int sum = 0;
            foreach (var element in input)
            {
                try
                {
                    int number;
                    //double number2;
                    if (int.Parse(element) > int.MaxValue)
                    {
                        throw new OverflowException();
                    }
                    if (!int.TryParse(element, out number))
                    {
                        //if(double.TryParse(element,out number2))
                        throw new FormatException();
                    }
                    
                    sum += number;
                    Console.WriteLine($"Element '{element}' processed - current sum: {sum}");
                }
                catch(FormatException ) 
                {
                    Console.WriteLine($"The element '{element}' is in wrong format!");
                }
                catch(OverflowException )
                {
                    Console.WriteLine($"The element '{element}' is out of range!");
                }
            }
        }
    }
}