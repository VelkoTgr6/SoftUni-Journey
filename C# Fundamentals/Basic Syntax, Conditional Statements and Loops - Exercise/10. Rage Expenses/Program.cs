using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.Rage_Expenses
{
    class Program
    {
        static void Main(string[] args)
        {
            int gameCount = int.Parse(Console.ReadLine());
            double headsetPrice = double.Parse(Console.ReadLine());
            double mousePrice = double.Parse(Console.ReadLine());
            double keyboardPrice = double.Parse(Console.ReadLine());
            double displayPrice = double.Parse(Console.ReadLine());
            int headsetCount = 0;
            int mouseCount = 0;
            int keyboardCount = 0;
            int displayCount = 0;

            for (int i = 1; i <= gameCount; i++)
            {
                if (i % 2 == 0)
                    headsetCount++;
                if (i % 3 == 0)
                    mouseCount++;
                if (i % 6 == 0)

                    keyboardCount++;
                if (i % 12 == 0 && keyboardCount != 0)
                    displayCount++;

            }
            Console.WriteLine($"Rage expenses: {(headsetPrice * headsetCount) + (mousePrice * mouseCount) + (keyboardCount * keyboardPrice) + (displayCount * displayPrice):f2} lv.");
        }
    }
}
