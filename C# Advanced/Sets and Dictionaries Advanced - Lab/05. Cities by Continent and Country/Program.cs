using static System.Formats.Asn1.AsnWriter;

namespace _05._Cities_by_Continent_and_Country
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> countries = new Dictionary<string, Dictionary<string,List<string>>>();
            int times = int.Parse(Console.ReadLine());
            for (int i = 0; i < times; i++)
            {
                string[] commandArr = Console.ReadLine().Split();

                string continent = commandArr[0];
                string country = commandArr[1];
                string city = commandArr[2];
                if (!countries.ContainsKey(continent))
                {
                    countries.Add(continent, new Dictionary<string,List< string>>());
                    //countries[continent].Add(country, city);
                }
                if (!countries[continent].ContainsKey(country))
                {
                    countries[continent].Add(country, new List<string>());
                }

                    countries[continent][country].Add(city);

            }
            foreach (var continent in countries)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"{country.Key} -> {String.Join(", ", country.Value)}");
                }
            }
        }
    }
}