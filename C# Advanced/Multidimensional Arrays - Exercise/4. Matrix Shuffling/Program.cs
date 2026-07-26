namespace _4._Matrix_Shuffling
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = dimensions[0];
            int cols = dimensions[1];
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string[] input = Console.ReadLine().Split();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            string command;
            bool isValid=false;

            while ((command=Console.ReadLine())!="END")
            {
                string[] array = command.Split();
                isValid = false;

                if (array[0] == "swap" && array.Length == 5)
                {
                    int row1 = int.Parse(array[1]);
                    int col1 = int.Parse(array[2]);
                    int row2 = int.Parse(array[3]);
                    int col2 = int.Parse(array[4]);

                    if (row1 <= matrix.GetLength(0)-1 && row2 <= matrix.GetLength(0)-1 &&
                        col1 <= matrix.GetLength(1)-1 && col2 <= matrix.GetLength(1)-1)
                    {
                        string current = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = current;
                        isValid = true;

                        for (int row = 0; row < rows; row++)
                        {
                            for (int col = 0; col < cols; col++)
                            {
                                Console.Write(matrix[row, col] + " ");
                            }
                            Console.WriteLine();
                        }

                    }
                }
                    if (isValid == false)
                    {
                        Console.WriteLine("Invalid input!");
                    }
                
            }
        }
    }
}