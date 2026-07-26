namespace _6._Jagged_Array_Modification
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][]jaggArray=new int[rows][];

            for (int row = 0; row < jaggArray.Length ; row++)
            {
                jaggArray[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }
            string command;
            while ((command=Console.ReadLine())!="END")
            {
                string[] arr = command.Split();
                string comd = arr[0];
                int row = int.Parse(arr[1]);
                int col = int.Parse(arr[2]);
                int value = int.Parse(arr[3]);
                bool isValid = true;
                if (row < 0 || jaggArray.Length<=row)
                {
                    isValid = false;
                }
                else
                {
                    if (jaggArray[row].Length <= col || col < 0)
                    {
                        isValid = false;
                    }
                }
                if (isValid)
                {
                    if (comd == "Add")
                    {
                        jaggArray[row][col] += value;
                    }
                    else if (comd == "Subtract")
                    {
                        jaggArray[row][col] -= value;
                    }
                }
                else
                {
                    Console.WriteLine("Invalid coordinates");
                }
            }
            for (int row = 0; row < jaggArray.Length; row++)
            {

                Console.Write(String.Join(" ",jaggArray[row]));
                Console.WriteLine();

            }
            
        }
    }
}