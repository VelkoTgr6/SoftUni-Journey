using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            double moneyChange = double.Parse(Console.ReadLine()) * 100;//*100 прави го в стотинки от лв.!
            int count = 0;
            while (moneyChange > 0)
            {
                if (moneyChange >= 200)
                    moneyChange -= 200;
                else if (moneyChange >= 100)
                    moneyChange -= 100;
                else if (moneyChange >= 50)
                    moneyChange -= 50;
                else if (moneyChange >= 20)
                    moneyChange -= 20;
                else if (moneyChange >= 10)
                    moneyChange -= 10;
                else if (moneyChange >= 5)
                    moneyChange -= 5;
                else if (moneyChange >= 2)
                    moneyChange -= 2;
                else if (moneyChange >= 1)
                    moneyChange -= 1;
                else
                {
                    moneyChange = 0;
                    break;
                }
                count++;
            }
            Console.WriteLine(count);
        }
    }
}
