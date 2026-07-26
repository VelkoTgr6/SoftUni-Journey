namespace SpecialCars
{
    public class Program
    {
        static void Main(string[] args)
        {
            string input;
            List<Car>cars = new List<Car>();
            List<Tire> listTire = new List<Tire>();
            List<Engine> engineList = new List<Engine>();
            while ((input = Console.ReadLine()) != "No more tires")
            {
                string[] inputArr = input.Split();
                Tire tire1 = new Tire(int.Parse(inputArr[0]), double.Parse(inputArr[1])
                , int.Parse(inputArr[2]), double.Parse(inputArr[3]),
                 int.Parse(inputArr[4]), double.Parse(inputArr[5]),
                 int.Parse(inputArr[6]), double.Parse(inputArr[7]));
                listTire.Add(tire1);
            }
            while((input = Console.ReadLine()) != "Engines done")
            {
                string[] inputArr = input.Split();
                Engine engine=new Engine(int.Parse(inputArr[0]), double.Parse(inputArr[1]));
                engineList.Add(engine);

            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] inputArr = input.Split();
                Car car=new Car(inputArr[0], inputArr[1], int.Parse(inputArr[2]), double.Parse(inputArr[3]), 
                    double.Parse(inputArr[4]), engineList[int.Parse(inputArr[5])], listTire[int.Parse(inputArr[6])]);
                cars.Add(car);
            }
            
                var special =cars.Where(c=>c.Year>=2017 && c.Engine.HorsePower>330
                && (c.Tire.Pressure1+c.Tire.Pressure2+ c.Tire.Pressure3 + c.Tire.Pressure4>9)
                && (c.Tire.Pressure1 + c.Tire.Pressure2 + c.Tire.Pressure3 + c.Tire.Pressure4 > 10))
                .ToList();

            foreach (var specCars in special)
            {
                specCars.Drive();
            }
            

        }
    }
}