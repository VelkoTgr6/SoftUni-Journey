namespace _2._Squares_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] sizes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            char[,] matrix = new char[sizes[0], sizes[1]];

            for (int row = 0; row < sizes[0]; row++)
            {
                char[] input = Console.ReadLine().Replace(" ", "").ToArray();

                for (int col = 0; col < sizes[1]; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int counter = 0;
            for (int row = 0; row < sizes[0] - 1; row++)
            {
                for (int col = 0; col < sizes[1] - 1; col++)
                {
                   char currentChar = matrix[row, col];

                    if (currentChar == matrix[row, col + 1])
                    {
                        if(currentChar== matrix[row + 1, col]&& currentChar == matrix[row + 1, col+1])
                        {
                            counter++;
                        }
                    }
                }
            }
            Console.WriteLine(counter);
        }
    }
}