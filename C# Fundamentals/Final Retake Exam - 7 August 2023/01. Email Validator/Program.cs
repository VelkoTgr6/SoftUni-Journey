using System.Text;

namespace _01._Email_Validator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder(Console.ReadLine());
            string command;
            while ((command=Console.ReadLine())!= "Complete")
            {
                if(command== "Make Upper")
                {
                    string upperCase = sb.ToString().ToUpper();
                    sb.Clear();
                    sb.Append(upperCase);
                    Console.WriteLine(sb.ToString());
                    continue;
                }
                if (command == "Make Lower")
                {
                    string lowerCase = sb.ToString().ToLower();
                    sb.Clear();
                    sb.Append(lowerCase);
                    Console.WriteLine(sb.ToString());
                    continue;
                }
                string[] commandArr = command.Split();
                switch (commandArr[0])
                {
                    //  case "Make Upper":
                    //   string upperCase=sb.ToString().ToUpper();
                    //    sb.Clear();
                    //    sb.Append(upperCase);
                    //    Console.WriteLine(sb.ToString());
                    //    break;
                    //case "Make Lower":
                    //    string lowerCase=sb.ToString().ToLower();
                    //    sb.Clear();
                    //    sb.Append(lowerCase);
                    //    Console.WriteLine(sb.ToString());
                    //    break;
                    case "GetDomain":
                        //string result = sb.ToString().Reverse().ToString().Substring(0, int.Parse(commandArr[1])).Reverse().ToString();
                        int startIndex = Math.Max(0, sb.Length - int.Parse(commandArr[1]));
                        string result = sb.ToString().Substring(startIndex);
                        Console.WriteLine(result);
                        break;
                    case "GetUsername":
                        if (sb.ToString().Contains('@'))
                        {
                            int atIndex = sb.ToString().IndexOf('@');
                            string foundResult = sb.ToString().Substring(0,atIndex);
                            Console.WriteLine(foundResult);
                        }
                        else
                        {
                            Console.WriteLine($"The email {sb.ToString()} doesn't contain the @ symbol.");
                        }
                        break;
                    case "Replace":
                        sb.Replace(commandArr[1], "-");
                        Console.WriteLine(sb.ToString());
                        break;
                    case "Encrypt":
                        foreach (char value in sb.ToString())
                        {
                            int asciiValue = Convert.ToInt32(value);
                            Console.Write(asciiValue+" ");
                        }
                        Console.WriteLine();
                        break;
                }
            }
        }
    }
}