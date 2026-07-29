using ExplicitInterfaces.Core;
using ExplicitInterfaces.Core.Interfaces;
using ExplicitInterfaces.IO;
using ExplicitInterfaces.IO.Intercases;
using ExplicitInterfaces.Models;
using ExplicitInterfaces.Models.Intercases;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            //IPerson person = new Citizen();
           
            IEngine engine=new Engine(writer, reader);
            engine.Run();
        }
    }
}