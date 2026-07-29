namespace NeedForSpeed
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Vehicle vehil = new Vehicle(50,500);
            
            vehil.Drive(15);
            RaceMotorcycle raceMotorcycle = new(50,300);
            raceMotorcycle.Drive(15);
            ;
        }
    }
}
