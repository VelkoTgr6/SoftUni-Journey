using System;
using System.Xml.Linq;

namespace _5._Play_Catch
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]input=Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int exceptionsCount = 0;
            while (exceptionsCount < 3)
            {
                
                string[] commands = Console.ReadLine().Split(" ");
                string command = commands[0];
                
                try
                {
                    if (!int.TryParse(commands[1], out int result))
                    {
                        exceptionsCount++;
                        throw new FormatException($"The variable is not in the correct format!");
                    }
                    if (int.Parse(commands[1]) < 0 || int.Parse(commands[1]) > input.Length - 1)
                    {
                        exceptionsCount++;
                        throw new ArgumentException($"The index does not exist!");
                    }
                    if (command == "Replace"||command=="Print")
                    {
                        if (!int.TryParse(commands[1], out int result3) || !int.TryParse(commands[2], out int result2))
                        {
                            exceptionsCount++;
                            throw new FormatException($"The variable is not in the correct format!");
                        }
                        if(command=="Print")
                        {
                            if(int.Parse(commands[2]) < 0 || int.Parse(commands[2]) > input.Length - 1)
                            {
                                exceptionsCount++;
                                throw new ArgumentException($"The index does not exist!");

                            }
                        }
                    }
                    int index = int.Parse(commands[1]);

                    switch (command)
                    {

                        case "Replace":
                           
                            input[index] = int.Parse(commands[2]);
                            break;
                        case "Show":
                            Console.WriteLine(input[index]);
                            break;
                        case "Print":
                            int size = int.Parse(commands[2]) - index+1;
                            int[] array = new int[size];
                            for (int i = 0; i <= size; i++)
                            {
                                for (int j = index; j <=int.Parse(commands[2]); j++)
                                {
                                    array[i] = input[j];
                                    i++;
                                }
                                    
                                
                            }
                            Console.WriteLine(String.Join(", ", array));
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(FormatException es)
                {
                    Console.WriteLine(es.Message);
                }
            }
            Console.WriteLine(String.Join(", ", input));

        }
    }
}