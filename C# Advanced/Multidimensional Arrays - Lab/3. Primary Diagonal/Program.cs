namespace _3._Primary_Diagonal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = new int[size, size];
            int sum = 0;
            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    sum += matrix[row, col];
                    row++;
                    
                }
            }
            Console.WriteLine(sum);

        }
    }
}