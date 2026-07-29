using System;
using ValidationAttributes.Modules;
using ValidationAttributes.Utils;

namespace ValidationAttributes
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            var person = new Person
            (
               null,
               -1
             );
            
            Console.WriteLine(Validator.IsValid(person));
            
        }
    }
}
