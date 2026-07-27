using System;
using System.Linq;
using System.Text;

namespace _03._Substring
{
    class Program
    {
        static void Main(string[] args)
        {
            string filter = Console.ReadLine();
            string text = Console.ReadLine();

            int remove = text.IndexOf(filter);
            while (remove != -1)
            {
                text = text.Remove(remove, filter.Length);
                remove = text.IndexOf(filter);
            }
            Console.WriteLine(text);
        }
    }
}
