namespace _5._Square_With_Maximum_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {

            string[] sizes = Console.ReadLine().Split(",").ToArray();

            int rows = int.Parse(sizes[0]);
            int cols = int.Parse(sizes[1]);
            int[,] matrix = new int[rows, cols];
            int maxSum = int.MinValue;

            for (int row = 0; row < rows; row++)
            {
                int[] input = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int maxRow = 0;
            int maxCol = 0;
            for (int row = 0; row < rows-1; row++)
            {
                for (int col = 0; col < cols-1; col++)
                {
                    int currentSum = 0;
                    currentSum += matrix[row, col];
                    currentSum += matrix[row, col + 1];
                    currentSum += matrix[row + 1, col];
                    currentSum += matrix[row + 1, col + 1];
                    if (currentSum>maxSum)
                    {
                        maxCol = col;
                        maxRow = row;
                        maxSum = currentSum;
                    }
                }
            }
            Console.WriteLine($"{matrix[maxRow, maxCol]} {matrix[maxRow, maxCol + 1]}");
            Console.WriteLine($"{matrix[maxRow+1, maxCol]} {matrix[maxRow+1, maxCol + 1]}");
            Console.WriteLine(maxSum);
        }
    }
}