namespace Fishing_Competition
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size=int.Parse(Console.ReadLine());
            char[,]area=new char[size,size];
            int fishCaught = 0;
            int currentRow = 0;
            int currentCol = 0;
            bool success = false;

            for(int row = 0; row < size; row++)
            {
                string path = Console.ReadLine();
                for (int col = 0; col < size; col++)
                {
                    area[row, col] = path[col];
                    if (path[col] == 'S')
                    {
                        currentRow = row;
                        currentCol = col;
                        area[row, col] = '-';
                    }
                }
            }
            string command;
            while((command=Console.ReadLine())!= "collect the nets")
            {
                if (command == "up")
                {
                    currentRow = (currentRow - 1 + size) % size;
                }
                else if (command == "down")
                {
                    currentRow = (currentRow + 1) % size;
                }
                else if (command == "left")
                {
                    currentCol = (currentCol - 1 + size) % size;
                }
                else if (command == "right")
                {
                    currentCol = (currentCol + 1) % size;
                }
                else if (command == "collect the nets")
                {
                    break;
                }
                if (char.IsDigit(area[currentRow,currentCol]))
                {
                    int fishInCell = int.Parse(area[currentRow,currentCol].ToString());
                    fishCaught += fishInCell;
                    area[currentRow,currentCol] = '-';
                }
                else if (area[currentRow,currentCol] == 'W')
                {
                    Console.WriteLine($"You fell into a whirlpool! The ship sank and you lost the fish you caught. Last coordinates of the ship: [{currentRow},{currentCol}]");
                    return;
                }
                if (fishCaught >= 20)
                {
                    success= true;
                    
                }
            }
            area[currentRow, currentCol] = 'S';
            if(success)
            {
                Console.WriteLine("Success! You managed to reach the quota!");
                Console.WriteLine($"Amount of fish caught: {fishCaught} tons.");
            }
            else
            {
                int lackOfFish = 20 - fishCaught;
                Console.WriteLine($"You didn't catch enough fish and didn't reach the quota! You need {lackOfFish} tons of fish more.");
                Console.WriteLine($"Amount of fish caught: {fishCaught} tons.");
            }
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{area[row,col]}");
                }
                Console.WriteLine();
                
            }
        }
    }
}