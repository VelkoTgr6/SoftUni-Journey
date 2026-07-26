namespace Mouse_In_The_Kitchen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]arr = Console.ReadLine().Split(",").Select(int.Parse).ToArray();
            string[,]cupboard=new string[arr[0], arr[1]];
            int mouseRow = -1;
            int mouseCol = -1;
            int totalCheeseNumber = 0;
            for (int row = 0; row < arr[0]; row++)
            {
                string arr2 = Console.ReadLine();
                for (int col = 0; col < arr[1]; col++)
                {
                    cupboard[row, col] = arr2[col].ToString();
                    if (cupboard[row, col] == "M")
                    {
                        mouseRow = row;
                        mouseCol = col;
                        cupboard[mouseRow, mouseCol] = "*";
                    }
                    if (cupboard[row,col]=="C")
                    {
                        totalCheeseNumber++;

                    }
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "danger")
            {
                if ((command == "left" && mouseCol == 0) ||
                    (command == "right" && mouseCol == cupboard.GetLength(1) - 1) ||
                    (command == "up" && mouseRow == 0) ||
                    (command == "down" && mouseRow == cupboard.GetLength(0) - 1))
                {
                    Console.WriteLine("No more cheese for tonight!");
                    break;
                }
                else
                {
                    if ((command == "left" && cupboard[mouseRow, mouseCol - 1] == "@") ||
                        (command == "right" && cupboard[mouseRow, mouseCol + 1] == "@") ||
                        (command == "up" && cupboard[mouseRow - 1, mouseCol] == "@") ||
                        (command == "down" && cupboard[mouseRow + 1, mouseCol] == "@"))
                    {
                        continue;
                    }
                    else
                    {
                        switch (command)
                        {
                            case "left":
                                mouseCol--;
                                break;
                            case "right":
                                mouseCol++;
                                break;
                            case "up":
                                mouseRow--;
                                break;
                            case "down":
                                mouseRow++;
                                break;
                        }
                        if (cupboard[mouseRow, mouseCol] == "C")
                        {
                            cupboard[mouseRow, mouseCol] = "*";
                            totalCheeseNumber--;
                            if (totalCheeseNumber == 0)
                            {
                                cupboard[mouseRow, mouseCol] = "M";
                                Console.WriteLine("Happy mouse! All the cheese is eaten, good night!");
                                break;
                            }
                            continue;
                        }
                        if (cupboard[mouseRow, mouseCol] == "T")
                        {
                            Console.WriteLine("Mouse is trapped!");
                            break;
                        }
                    }

                }
            }
                if (command == "danger")
                {
                    Console.WriteLine("Mouse will come back later!");
                }
                cupboard[mouseRow, mouseCol] = "M";

            for (int i = 0; i < cupboard.GetLength(0); i++)
            {
                for (int j = 0; j < cupboard.GetLength(1); j++)
                {
                    Console.Write(cupboard[i, j]);
                }
                Console.WriteLine();
            }


        }
    }
}