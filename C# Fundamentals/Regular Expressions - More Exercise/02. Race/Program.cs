using System.Text.RegularExpressions;
using System.Linq;
using System.Text;

namespace _02._Race
{
    internal class Program
    {
        class Participant
        {
            public string Name { get; set; }

            public uint Distance { get; set; }

        }
        static void Main(string[] args)
        {
            List < Participant > participants= new List<Participant>();
            string[] namesArr = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < namesArr.Length; i++)
            {
                //creating new participant
                Participant participant = new Participant();
                participant.Name = namesArr[i];
                participant.Distance =0;
                participants.Add(participant);
            }
            string lettersPattern = @"[A-Za-z]";
            string digitsPattern = @"\d";
            string input;

            while ((input=Console.ReadLine())!= "end of race")
            {
                StringBuilder name = new StringBuilder();

                foreach (Match match in Regex.Matches(input,lettersPattern))
                {
                    name.Append(match.Value);
                }
                uint distance = 0;
                foreach (Match match in Regex.Matches(input,digitsPattern))
                {
                    distance += uint.Parse(match.Value);
                }      
                var foundParticipant = participants.FirstOrDefault(p => p.Name == name.ToString());//searching for name

                if (foundParticipant!=null)
                {
                    foundParticipant.Distance += distance;
                }

            }
             List<Participant> orderedParticipants = participants
                .OrderByDescending(p => p.Distance)//order by distance(descending)
                .Take(3)
                .ToList();//вземи първите 3ма
            if (participants.Count() >= 3)
            {
                Console.WriteLine($"1st place: {orderedParticipants[0].Name}\n" +
                    $"2nd place: {orderedParticipants[1].Name}\n" +
                    $"3rd place: {orderedParticipants[2].Name}");
            }
        }
    }
}