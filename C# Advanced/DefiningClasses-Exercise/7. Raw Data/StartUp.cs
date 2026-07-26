using RawData;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n=int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Car car = new(
                    input[0],
                    int.Parse(input[1]),
                    int.Parse(input[2]),
                    int.Parse(input[3]),
                    input[4],
                    double.Parse(input[5]),
                    int.Parse(input[6]),
                    double.Parse(input[7]),
                    int.Parse(input[8]),
                    double.Parse(input[9]),
                    int.Parse(input[10]),
                    double.Parse(input[11]),
                    int.Parse(input[12])
                    ); 
                cars.Add(car);
            }
            string fiilter=Console.ReadLine();

            string[] filteredCars;

            if (fiilter == "fragile")
            {
                filteredCars=cars.Where(c=>c.Cargo.Type==fiilter && c.Tires.Any(t=>t.Pressure<1)).Select(c=>c.Model).ToArray();
            }
            else
            {
                filteredCars=cars.Where(c=>c.Cargo.Type==fiilter && c.Engine.Power>250).Select(c=>c.Model).ToArray();
            }

            Console.WriteLine(string.Join(Environment.NewLine, filteredCars));
            
        }
    }
}