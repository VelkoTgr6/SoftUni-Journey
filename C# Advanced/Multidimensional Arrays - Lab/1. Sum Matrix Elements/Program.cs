namespace _1._Sum_Matrix_Elements
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]rowsCols=Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            int[,] matrix = new int[rowsCols[0], rowsCols[1]];
            int sum = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[]input= Console.ReadLine().Split(",").Select(int.Parse).ToArray();
                for (int cols = 0; cols < matrix.GetLength(1); cols++)
                {
                    matrix[row, cols] = input[cols];
                }

            }
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    sum += matrix[row, col];
                }
            }
            Console.WriteLine(matrix.GetLength(0));
            Console.WriteLine(matrix.GetLength(1));
            Console.WriteLine(sum);
        }
    }
}