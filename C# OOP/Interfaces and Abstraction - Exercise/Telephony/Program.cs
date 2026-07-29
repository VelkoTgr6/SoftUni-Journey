using Telephony.Models.Interfaces;

namespace Telephony
{
   public class Program
    {
        public static void Main(string[] args)
        {
            string[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            ICalling phone;

            foreach (string number in numbers)
            {
                if (number.Length == 10)
                {
                    phone = new Smartphone();
                }
                else
                {
                    phone=new StationaryPhone();
                }
                try
                {
                    Console.WriteLine(phone.Call(number));
                }
                catch(Exception ex) 
                {
                    Console.WriteLine(ex.Message);
                }
            }
            IBrowsable browsable=new Smartphone();

            foreach (string url in urls)
            {
                try
                {
                    Console.WriteLine(browsable.Browse(url));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
            
        
   }
}