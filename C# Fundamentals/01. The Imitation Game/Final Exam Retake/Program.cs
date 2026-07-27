using System.Text;

namespace Final_Exam_Retake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string input="";
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            while((input=Console.ReadLine())!= "Decode")
            {
                string[] inputArr = input.Split("|", StringSplitOptions.RemoveEmptyEntries);
                
                switch (inputArr[0])
                {
                    case "Move":
                        string firstSubstring = sb.ToString(0, int.Parse(inputArr[1]));
                        sb.Remove(0, int.Parse(inputArr[1]));
                        sb.Append(firstSubstring); break;
                    case "Insert":
                        sb.Insert(int.Parse(inputArr[1]),inputArr[2]);break;
                    case "ChangeAll":
                        sb.Replace(inputArr[1],inputArr[2]);break;
                }
            }
            Console.WriteLine($"The decrypted message is: {sb.ToString()}");
        }
    }
}