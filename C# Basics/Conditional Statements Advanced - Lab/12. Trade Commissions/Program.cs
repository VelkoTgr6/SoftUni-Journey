using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Trade_Commissions
{
    class Program
    {
        static void Main(string[] args)
        {
            string city = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());
            double cummision = 0;

            switch (city)
            {


                case "Sofia":
                    if (sales < 0)
                    {
                        Console.WriteLine("error");
                    }

                    if (sales >= 0 && sales <= 500)
                    {
                        cummision = sales * 0.05;//извеждаме като :f2 (0.05)
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        cummision = sales * 0.07;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        cummision = sales * 0.08;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 10000)
                    {
                        cummision = sales * 0.12;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    break;
                case "Varna":
                    if (sales < 0)
                    {
                        Console.WriteLine("error");
                    }

                    if (sales >= 0 && sales <= 500)
                    {
                        cummision = sales * 0.045;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        cummision = sales * 0.075;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        cummision = sales * 0.10;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 10000)
                    {
                        cummision = sales * 0.13;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    break;
                case "Plovdiv":
                    if (sales < 0)//проверява дали числото е <0 
                    {
                        Console.WriteLine("error");
                    }

                    if (sales >= 0 && sales <= 500)
                    {
                        cummision = sales * 0.055;//не слагаме повече 0 пр.0.055 понеже ще премести-
                                                  //запетаята още !при 5.5% (0.55=55%)
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 500 && sales <= 1000)
                    {
                        cummision = sales * 0.08;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 1000 && sales <= 10000)
                    {
                        cummision = sales * 0.12;
                        Console.WriteLine($"{cummision:f2}");
                    }
                    else if (sales > 10000)
                    {
                        cummision = sales * 0.145;
                        Console.WriteLine($"{cummision:f2}");
                    }

                    break;
                default: Console.WriteLine("error"); break;
            }
        }
    }
}
