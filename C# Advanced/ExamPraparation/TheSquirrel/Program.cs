namespace TheSquirrel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size=int.Parse(Console.ReadLine());
            char[,]matrix=new char[size,size];
            string[]directions=Console.ReadLine().Split(", ",StringSplitOptions.RemoveEmptyEntries).ToArray();
            int hazelnutsCount = 0;
            int currentRow=0;
            int currentCol=0;

            for (int row = 0; row < size; row++)
            {
                string pathCol = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = pathCol[col];
                    if (pathCol[col]=='s')
                    {
                        currentRow=row;
                        currentCol=col;
                        matrix[row, col] = '*';
                    }
                    
                }
            }
            foreach (var direction in directions)
            {
                switch (direction)
                {
                    case "left":
                        if(currentCol-1>=0 && currentCol-1<=size-1)
                        {
                            currentCol--;
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                            matrix[currentRow, currentCol] = 's';
                            return;
                        }
                        break;
                    case "right":
                        if(currentCol+1>=0 && currentCol+1<=size-1)
                        {
                            currentCol++;
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                            matrix[currentRow, currentCol] = 's';
                            return;
                        }
                        break;
                    case "up":
                        if (currentRow-1>=0&& currentRow-1<=size-1)
                        {
                            currentRow--;
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                            matrix[currentRow, currentCol] = 's';
                            return;
                        }
                        break;
                    case "down":
                        if(currentRow+1>=0&& currentRow + 1 <= size - 1)
                        {
                            currentRow++;
                        }
                        else
                        {
                            Console.WriteLine("The squirrel is out of the field.");
                            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                            matrix[currentRow, currentCol] = 's';
                            return;
                            
                        }
                        break;
                }
                if (matrix[currentRow, currentCol] == 'h')
                {
                    matrix[currentRow, currentCol] = '*';
                    hazelnutsCount++;
                    if(hazelnutsCount == 3)
                    {
                        matrix[currentRow, currentCol] = 's';
                        Console.WriteLine("Good job! You have collected all hazelnuts!");
                        Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                        return;
                    }
                }
                else if (matrix[currentRow, currentCol] == 't')
                {
                    matrix[currentRow, currentCol] = 's';
                    Console.WriteLine("Unfortunately, the squirrel stepped on a trap...");
                    Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");
                    return;
                }

            }
            if(hazelnutsCount<3)
            {
                Console.WriteLine("There are more hazelnuts to collect.");
            }
            Console.WriteLine($"Hazelnuts collected: {hazelnutsCount}");

        }
    }
}