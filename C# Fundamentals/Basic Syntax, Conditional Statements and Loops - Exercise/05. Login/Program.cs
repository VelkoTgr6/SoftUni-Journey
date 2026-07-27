using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.Login
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string username = Console.ReadLine();
                string password = "";
                int attemptCount = 0;
                bool didEND = false;

                for (int i = username.Length - 1; i >= 0; i--)
                {
                    password += username[i];
                }

                while (true)
                {
                    string attempt = Console.ReadLine();

                    if (attempt != password)
                    {
                        attemptCount++;

                        if (attemptCount == 4)
                        {
                            Console.WriteLine($"User {username} blocked!");
                            didEND = true;
                            break;

                        }

                        Console.WriteLine("Incorrect password. Try again.");
                    }

                    else
                    {
                        Console.WriteLine($"User {username} logged in.");
                        didEND = true;
                        break;

                    }

                }
                if (didEND)
                    break;
            }
    }
}
