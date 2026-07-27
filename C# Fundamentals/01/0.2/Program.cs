namespace _0._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[]field=Console.ReadLine().Split("|").Select(int.Parse).ToArray();
            string command;
            int points = 0;

            while ((command = Console.ReadLine()) != "Game over")
            {
                string[] index = command.Split("@").ToArray();

                if (index[0] != "Reverse")
                {
                    int index1 = int.Parse(index[1]);
                    int index2 = int.Parse(index[2]);

                    if (index1 == 0 || index2 == 0)
                    {
                        index1 = 1;
                        index2 = 1;
                    }
                    switch (index[0])
                    {
                        case "Shoot Left":
                            if (index1 <= field.Length)
                            {
                                int sumLenght = index1 + index2;

                                if (sumLenght > field.Length)
                                {
                                    if (field[^1] < 5)
                                    {
                                        field[sumLenght] = 0;
                                        points += 5;
                                        continue;
                                    }
                                    field[^1] -= 5;
                                    points += 5;
                                }

                                else
                                {
                                    field[sumLenght] -= 5;
                                    points += 5;
                                }

                            }
                            break;
                        case "Shoot Right":
                            if (index1 <= field.Length)
                            {
                                int sumLenght = index1 + index2;

                                if (sumLenght > field.Length)
                                {
                                    field[0] -= 5;
                                    points += 5;
                                }
                                else
                                {
                                    field.Reverse();
                                    field[sumLenght] -= 5;
                                    points += 5;
                                    field.Reverse();
                                }

                            }
                            break;

                    }
                }

                else
                {
                    field.Reverse();
                }
            }
            
            
            Console.WriteLine(string.Join(" - ", field));
            Console.WriteLine($"John finished the archery tournament with {points} points!");
        }
    }
}