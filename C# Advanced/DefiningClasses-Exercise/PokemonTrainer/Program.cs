using System.Xml.Linq;

namespace PokemonTrainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            string command;
            Dictionary<string, Trainer> trainers = new();
            while ((command = Console.ReadLine()) != "Tournament")
            {
                string[] input = command.Split();
                string trainerName = input[0];
                string pokemonName = input[1];
                string pokemonElement = input[2];
                int pokemonHealth = int.Parse(input[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }
                trainers[trainerName].PokemonsList.Add(new Pokemon(pokemonName,pokemonElement, pokemonHealth));

            }
            while ((command = Console.ReadLine()) != "End")
            {
                foreach (var trainer in trainers.Values)
                {
                    var correnct = trainer.PokemonsList.Where(p => p.Element == command).ToList();
                    if (correnct.Any())
                    {
                        for (int i = 0; i < correnct.Count; i++)
                            trainer.BadgesCount++;
                    }
                    else
                    {
                        foreach (var pokemon in trainer.PokemonsList.ToList())
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                trainer.PokemonsList.Remove(pokemon);
                            }

                        }
                    }
                }
            }
            foreach (var trainer in trainers.Values.OrderByDescending(t=>t.BadgesCount))
            {

                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.PokemonsList.Count}");
            }
        }
    }
}