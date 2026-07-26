namespace _06._Songs_Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr =Console.ReadLine().Split(", ").ToArray();
            Queue<string> songQueue=new Queue<string>(arr);
            while (songQueue.Any())
            {
                arr = Console.ReadLine().Split().ToArray();
                
                if (arr[0]=="Play")
                {
                    songQueue.Dequeue();
                }
                else if (arr[0]=="Show")
                {
                    Console.WriteLine(string.Join(", ", songQueue));
                }   
                else if (arr[0] == "Add" )
                {
                    string song = string.Join(" ", arr, 1, arr.Length - 1);
                    if(!songQueue.Contains(song))    
                        songQueue.Enqueue(song);
                    else
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                }
                
            }
            Console.WriteLine("No more songs!");
        }
    }
}