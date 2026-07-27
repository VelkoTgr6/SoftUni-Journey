namespace MidExAMretake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal singleUserIncome = decimal.Parse(Console.ReadLine());
            int numUsers = int.Parse(Console.ReadLine());
            int counter = 0;
            decimal sumUsers = 0;
 

            for (int i = 0; i <numUsers; i++)
            {
                counter++;
                int numSearchesPerUser = int.Parse(Console.ReadLine());
                if (counter % 3 == 0)
                {
                    sumUsers += numSearchesPerUser * (singleUserIncome * 3);
                }

                if (numSearchesPerUser>5)
                {
                    sumUsers += numSearchesPerUser * singleUserIncome*2;
                }
                if (numSearchesPerUser == 1)
                {

                    continue;
                }
                if(numSearchesPerUser>1)
                {
                    sumUsers += numSearchesPerUser * singleUserIncome;
                }
             
            }

            Console.WriteLine($"Total money earned: {sumUsers:f2}");
            
        }
    }
}