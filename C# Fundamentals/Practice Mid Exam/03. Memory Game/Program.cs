using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace _03._Memory_Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string sequence = Console.ReadLine();
            List<string> listSequence= new List<string>();
            listSequence=sequence.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToList();   
            string command ;
            int counter=0;
            while ((command= Console.ReadLine())!="end")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
                int[]index=new int[2];
                index[0] = int.Parse(input[0]);
                index[1] = int.Parse(input[1]);
                counter++;

                if (index[0] == index[1] || (index[0] > listSequence.Count || index[1] >listSequence.Count))
                {
                    listSequence.Insert(listSequence.Count / 2, "-" + counter.ToString()+"a");
                    listSequence.Insert(listSequence.Count / 2,"-"+counter.ToString() + "a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }

                else if (index[0] == index[1] || (index[0]<0 || index[1] < 0))
                {
                    listSequence.Insert(listSequence.Count / 2, "-" + counter.ToString() + "a");
                    listSequence.Insert(listSequence.Count / 2, "-" + counter.ToString() + "a");
                    Console.WriteLine("Invalid input! Adding additional elements to the board");
                }
                else 
                {
                    if (listSequence.ElementAt(index[0]) == listSequence.ElementAt(index[1]))
                    {
                        Console.WriteLine($"Congrats! You have found matching elements - {listSequence.ElementAt(index[0])}!");
                        string removeWord = listSequence[index[0]];
                        listSequence.RemoveAll(x => x == removeWord);
                        
                    }
                    
                    else
                    {
                        Console.WriteLine("Try again!");
                    }
                }
                if (listSequence.Count == 0)
                {
                    Console.WriteLine($"You have won in {counter} turns!");
                    break;
                }

            }
            if (listSequence.Count>=1)
            {
                Console.WriteLine("Sorry you lose :(");
                Console.WriteLine(string.Join(" ", listSequence));
            }


        }
    }
}

