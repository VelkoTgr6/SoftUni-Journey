namespace _5._Snake_Moves
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];
            string snake = Console.ReadLine();
            string[] snakeArr = new string[snake.Length];

            for (int i = 0; i < snake.Length; i++)
            {
                snakeArr[i] = snake[i].ToString();
            }

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = snakeArr[col];
                }
            }

        }
    }
}