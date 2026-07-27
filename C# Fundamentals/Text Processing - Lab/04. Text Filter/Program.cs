using System;
using System.Linq;
using System.Text;

namespace _04._Text_Filter
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] filter = Console.ReadLine().Split(", ");
            string text = Console.ReadLine();
            foreach (var banWord in filter)
            {
                if (text.Contains(banWord))
                {
                    text = text.Replace(banWord,
                    new string('*', banWord.Length));
                }
            }
            Console.WriteLine(text);
        }
    }
}
