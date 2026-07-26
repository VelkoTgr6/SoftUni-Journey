namespace _4._Symbol_in_Matrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];

            for (int row = 0; row < size; row++)
            {
                char[] input = Console.ReadLine().ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            char[] symbol=Console.ReadLine().ToArray();
            bool isFound = false;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    if (symbol[0] == matrix[row,col])
                    {
                        Console.WriteLine($"({row}, {col})");
                        isFound = true;
                        break;
                    }
                }
                if (isFound)
                    break;
            }
            if ( isFound==false )
            {
                Console.WriteLine($"{symbol[0]} does not occur in the matrix");
            }

        }
    }
}