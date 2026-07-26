using System.Text.RegularExpressions;

namespace _08._SoftUni_Party
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command;
            HashSet<string> regular = new HashSet<string>();
            HashSet<string> vip=new HashSet<string>();
            string pattern = @"^\d";

            while ((command=Console.ReadLine())!="PARTY")
            {
                bool isMatch = Regex.IsMatch(command, pattern);
                if (isMatch)
                {
                    vip.Add(command);
                }
                else
                {
                    regular.Add(command);
                }
            }
            while ((command = Console.ReadLine()) != "END")
            {
                if (regular.Contains(command))
                {
                    regular.Remove(command);
                }
                else if (vip.Contains(command)) ;
                {
                    vip.Remove(command);
                }
            }
            
            Console.WriteLine(regular.Count + vip.Count);
            foreach (var item in vip)
            {
                Console.WriteLine(item);
            }
            foreach (var item in regular)
            {
                Console.WriteLine(item);
            }
        }
    }
}