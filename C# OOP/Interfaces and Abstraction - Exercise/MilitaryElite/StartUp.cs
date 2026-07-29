using MilitaryElite.Core.Interfaces;
using MilitaryElite.Core;

namespace MilitaryElite
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}