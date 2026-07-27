namespace _05._Array_Modifier
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input=new List <int> (Console.ReadLine().Split().Select(int.Parse).ToArray());
            string command;
            while ((command=Console.ReadLine())!="end")
            {
                string[] arrayCommand = command.Split().ToArray();

                if (arrayCommand[0] == "decrease")
                {
                    for (int i = 0; i < input.Count; i++)
                    {
                        input[i] -= 1;
                    }
                    continue;
                }

                    int index1 = int.Parse(arrayCommand[1]);
                    int index2 = int.Parse(arrayCommand[2]);
                
                switch (arrayCommand[0])
                {
                    case "swap":

                        int temp = input[index1];
                        input[index1] = input[index2];
                        input[index2] = temp;
                        break;
                    case "multiply":
                        input[index1] *= input[index2];
                        break;
                    // case "decrease":
                    //   for (int i = 0; i < input.Count; i++)
                    //   {
                    //       input[i] -= 1;
                    //   }
                    //   break;
                }

            }
            Console.WriteLine(string.Join(", ", input));
            
        }
    }
}