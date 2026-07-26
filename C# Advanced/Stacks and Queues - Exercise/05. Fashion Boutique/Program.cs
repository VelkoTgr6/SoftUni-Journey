namespace _05._Fashion_Boutique
{
    internal class Program
    {
        static void Main(string[] args)
        
        {
            int[] clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(clothes);
            int capacity = int.Parse(Console.ReadLine());
            int racks=1;
            int sum=0;
            int index = 0;

            foreach (var item in stack)
            {
                index++;
                if (sum+item < capacity)
                {
                    sum += item;
                }
                else if(sum+item==capacity&&stack.Count>index)
                {
                    sum = 0;
                   // sum += item;
                    racks++;
                }
                else if (sum+item>capacity)
                {
                     sum = 0;
                     sum += item;
                     racks++;
                }
                
            }
            Console.WriteLine(racks);
        }
    }
}