namespace _1._Diagonal_Difference
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            int[,]matrix=new int[size,size];

            for (int row = 0; row < size; row++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            int sum1 = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    sum1 += matrix[row, col];
                    row++;
                }
            }
            int sum2 = 0;
            for (int row = 0; row < size; row++)
            {
                for (int col = size-1; col >= 0; col--)
                {
                    sum2 += matrix[row, col];
                    row++;
                }
            }
            Console.WriteLine(Math.Abs(sum1-sum2));


        }
    }
}