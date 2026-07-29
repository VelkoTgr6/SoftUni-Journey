namespace _6._Money_Transactions
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(",");
            Dictionary<int,double>accountInfo = new Dictionary<int,double>();

            foreach (var item in input)
            {
                string[] info = item.Split("-");
                int accNum= int.Parse(info[0]);
                double balance = double.Parse(info[1]);
                accountInfo.Add(accNum, balance);
            }
            string commandInput;
            while ((commandInput=Console.ReadLine())!="End")
            {
                string[] tokens = commandInput.Split();
                string command = tokens[0];
                int accNumb= int.Parse(tokens[1]);
                double sum= double.Parse(tokens[2]);
                try
                {
                    if (!accountInfo.ContainsKey(accNumb))
                    {
                        throw new ArgumentException("Invalid account!");
                    }
                    if (command != "Withdraw" && command != "Deposit") 
                    {
                        throw new ArgumentException("Invalid command!");
                    }
                    if(command== "Withdraw" && sum > accountInfo[accNumb])
                    {
                        throw new ArgumentException("Insufficient balance!");
                    }
                    switch (command)
                    {
                        case "Withdraw":
                            accountInfo[accNumb] -= sum;
                            break;
                        case "Deposit":
                            accountInfo[accNumb] += sum;
                            break;


                    }
                    Console.WriteLine($"Account {accNumb} has new balance: {accountInfo[accNumb]:f2}");
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }

            }
        }
    }
}