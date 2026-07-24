using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.On_Time_for_the_Exam
{
    class Program
    {
        static void Main(string[] args)
        {
            int hourOfExam = int.Parse(Console.ReadLine());
            int minutesOfExam = int.Parse(Console.ReadLine());
            int hourOfComming = int.Parse(Console.ReadLine());
            int minutesOfComming = int.Parse(Console.ReadLine());

            int examTotalMinutes = hourOfExam * 60 + minutesOfExam;//rabotim s minuti
            int arrivalTotalMinutes = hourOfComming * 60 + minutesOfComming;

            if (arrivalTotalMinutes > examTotalMinutes)
            {
                Console.WriteLine("Late");
                int minutesDifference = arrivalTotalMinutes - examTotalMinutes;
                if (minutesDifference < 60)
                {
                    Console.WriteLine($"{minutesDifference} minutes after the start");
                }
                else
                {
                    int hours = minutesDifference / 60;
                    int minutes = minutesDifference % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours after the start");
                }

            }
            else if (arrivalTotalMinutes < examTotalMinutes - 30)
            {
                Console.WriteLine("Early");
                int minutesDifference = examTotalMinutes - arrivalTotalMinutes;
                if (minutesDifference < 60)
                {
                    Console.WriteLine($"{minutesDifference} minutes before the start");
                }
                else
                {
                    int hours = minutesDifference / 60;
                    int minutes = minutesDifference % 60;
                    Console.WriteLine($"{hours}:{minutes:d2} hours before the start");
                }
            }
            else
            {
                Console.WriteLine("On time");
                int minutesDifference = examTotalMinutes - arrivalTotalMinutes;
                Console.WriteLine($"{minutesDifference} minutes before the start");

            }
        }
    }
}
