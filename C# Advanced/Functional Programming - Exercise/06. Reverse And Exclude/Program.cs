namespace _06._Reverse_And_Exclude
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<List<int>,int, Stack<int>> operations = (numbers,divisbleNumb) =>
            {
                Stack<int> result = new();
                foreach (var number in numbers)
                {
                    if (number % divisbleNumb != 0)
                    {
                        result.Push(number);
                    }
                }
                return result;
            };
            List<int>numbers=Console.ReadLine().Split().Select(int.Parse).ToList();
            int divisibleNumb=int.Parse(Console.ReadLine());    

            Console.WriteLine(String.Join(" ",operations(numbers,divisibleNumb)));
        }
    }
}