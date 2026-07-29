namespace _01._Square_Root
{
    internal class Program
    {
        static void Main(string[] args)
        {
			try
			{
				int input = int.Parse(Console.ReadLine());
				if(input<0)
				{
					throw new ArgumentException("Invalid number.");
				}
				else
				{
					Console.WriteLine(Math.Sqrt(input));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			finally
			{ 
				Console.WriteLine("Goodbye.");
			}
        }
    }
}