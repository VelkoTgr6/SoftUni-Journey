using System.Security.Cryptography;
using System.Text;

namespace _01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string spell = Console.ReadLine();
            StringBuilder sb = new StringBuilder(spell);
            string command;

            while ((command = Console.ReadLine())!="Abracadabra")
            {
                string[] commandArray = command.Split(" ").ToArray();
                switch (commandArray[0])
                {
                    case "Abjuration":
                        sb.ToString().ToUpper();
                        Console.WriteLine(sb.ToString().ToUpper());
                        break;
                    case "Necromancy":
                        sb.ToString().ToLower();
                        Console.WriteLine(sb.ToString().ToLower());
                        break;
                    case "Illusion":
                        if (int.Parse(commandArray[1]) <= sb.Length)
                        { 
                          sb[(int.Parse(commandArray[1]))] = char.Parse(commandArray[2]);
                          sb.ToString();
                            Console.WriteLine("Done!");
                        }
                        else
                        {
                            Console.WriteLine("The spell was too weak.");
                        }
                        break;
                    case "Divination":
                        if (sb.ToString().Contains(commandArray[1]))
                       {
                          sb.Replace(char.Parse(commandArray[1]), char.Parse(commandArray[2]));
                        }
                        else
                           continue;
                              break;
                    case "Alteration":
                        if (true)//sb.ToString().Contains(commandArray[1]))
                        {
                            //var altIndex = sb.ToString().IndexOf(commandArray[1]);
                            //sb.Remove(altIndex, altIndex);
                            sb.ToString();
                            Console.WriteLine(sb);
                        }
                        
                       else
                           continue;

                        break;
                    default:
                        Console.WriteLine("The spell did not work!");
                        break;    
                }
            }
            //Console.WriteLine(sb.ToString());

        }
    }
}