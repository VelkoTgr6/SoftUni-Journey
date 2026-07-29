namespace ClassBoxData
{
    internal class Program
    {
       public static void Main(string[] args)
        {
           List<double> list = new List<double>();
            for (int i = 0; i < 3; i++)
            {
                double input = double.Parse(Console.ReadLine());
                list.Add(input);
            }
            
            try
            {
                Box box = new(list[0], list[1], list[2]);
                Console.WriteLine($"Surface Area - {box.SurfaceArea():f2}");
                Console.WriteLine($"Lateral Surface Area - {box.LateralSurfaceArea():F2}");
                Console.WriteLine($"Volume - {box.Volume():F2}");
            }
            catch (Exception ex) 
            { 
                Console.WriteLine(ex.Message);
            }


            
        }
    }
}