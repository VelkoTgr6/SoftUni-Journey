using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokemonTrainer
{
    public class Trainer
    {
        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> PokemonsList { get; set; } 
        public Trainer(string name)
        {
            
            Name = name;
            BadgesCount = 0;
            PokemonsList = new List<Pokemon>();
        }

        public void AddBadge(Trainer trainer)
        {
            this.BadgesCount+=1;
        }

       

    }
}
