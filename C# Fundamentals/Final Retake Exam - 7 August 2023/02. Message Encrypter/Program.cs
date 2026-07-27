using System.Text;
using System.Text.RegularExpressions;

namespace _02._Message_Encrypter
{
    internal class Program
    {
        class Message
        {
            public string Tag { get; set; }

            public string Group1 { get; set; }
            public string Group2 { get; set; }
            public string Group3 { get; set; }


        }
        static void Main(string[] args)
        {
            string pattern = @"\*(?<tag>[A-Z][a-z]{3,})\*: (?<message>\[(?<group1>\w)\]\|\[(?<group2>\w)\]\|\[(?<group3>\w)\])\|$|\@(?<tag>[A-Z][a-z]{3,})\@: (?<message>\[(?<group1>\w)\]\|\[(?<group2>\w)\]\|\[(?<group3>\w)\])\|$";
            int n = int.Parse(Console.ReadLine());
            bool isValid = false;
            List<Message> messages = new List<Message>();
            messages.Add
            for (int i = 0; i < n; i++)
            {
                isValid = false;
                string input = Console.ReadLine();
                foreach (Match match in Regex.Matches(input,pattern))
                {
                    isValid = true;
                    Message message = new Message();
                    message.Tag = match.Groups["tag"].Value;
                    message.Group1 = match.Groups["group1"].Value;
                    message.Group2 = match.Groups["group2"].Value;
                    message.Group3 = match.Groups["group3"].Value;
                    messages.Add(message);
                    string gr1 = message.Group1;
                    byte[] group1 = Encoding.ASCII.GetBytes(message.Group1);
                    byte[] group2 = Encoding.ASCII.GetBytes(message.Group2);
                    byte[] group3 = Encoding.ASCII.GetBytes(message.Group3);
                    Console.WriteLine($"{message.Tag}: {group1[0]} {group2[0]} {group3[0]}");
                }
                if (isValid == false)
                {
                    Console.WriteLine("Valid message not found!");
                }
            }
        }
    }
}