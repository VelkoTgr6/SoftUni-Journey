namespace Shapes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Rectangle rectangle = new Rectangle(20, 30);
            rectangle.CalculateArea();
            Console.WriteLine(rectangle.Draw()+rectangle.CalculateArea());

            Circle circle = new Circle(20);
            circle.CalculateArea();
            Console.Write(circle.Draw()+circle.CalculateArea());
        }
    }
}