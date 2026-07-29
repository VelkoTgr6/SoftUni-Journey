using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;
        private readonly ICollection<IAnimal> animals;
        private readonly IFood food;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input;
            while((input=reader.ReadLine())!="End") 
            {
                //string[] arr=input.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                //string[] foodInput=reader.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);
                IAnimal animal = null;
                try
                {
                    //animals.Add(animalFactory.CreateAnimal(arr));
                    animal =CreateAnimal(input);
                    IFood food = CreateFood();
                    //var animal = animals.FirstOrDefault(a => a.GetType().Name == arr[0]);
                    writer.WriteLine(animal.AskFood());
                    animal.Eat(food); 
                    
                }
                catch(Exception ex)
                {
                    writer.WriteLine(ex.Message);
                }
                animals.Add(animal);
            }
            foreach (var animal in animals)
            {
                writer.WriteLine(animal.ToString());
            }
        }
        private IAnimal CreateAnimal(string command)
        {
            string[] animalArgs = command
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.CreateAnimal(animalArgs);

            return animal;
        }
        private IFood CreateFood()
        {
            string[] foodTokens = reader.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string foodType = foodTokens[0];
            int foodQuantity = int.Parse(foodTokens[1]);

            IFood food = foodFactory.CreateFood(foodType, foodQuantity);

            return food;
        }

    }
}
