namespace _03._Maximum_and_Minimum_Element
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>();
            //int command = 0;
            for (int i = 0; i < n; i++)
            {
                //command = int.Parse(Console.ReadLine());
                int[] arr =Console.ReadLine().Split().Select(int.Parse).ToArray();
                if (arr[0] == 1)
                {
                    stack.Push(arr[1]);
                }
                else if (arr[0] ==2)
                {
                    stack.Pop();
                }
                else if (arr[0] == 3 && stack.Count>0)
                {
                    Console.WriteLine(stack.Max());
                }
                else if (arr[0] == 4 && stack.Count > 0)
                {
                    Console.WriteLine(stack.Min());
                }
            }
            Console.WriteLine(String.Join(", ",stack));
        }
    }
}