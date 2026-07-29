using Library.Core.Appernders;
using Library.Core.Layout;
using Library.Core.Loggers;
using LoggerConsoleApp.CustomLayouts;
using LoggerCore.Core.IO;

namespace LoggerConsoleApp
{
    internal class StartUp
    {
        static void Main(string[] args)
        {
            var xmlLayout = new XmlLayout();
            var consoleAppender = new ConsoleAppender(xmlLayout);

            var file = new LogFile("test","xml",Directory.GetCurrentDirectory());
            var fileAppender=new FileAppender(xmlLayout, file);

            var logger = new Logger(consoleAppender,fileAppender);
            logger.Fatal("3/31/2015 5:23:54 PM", "mscorlib.dll does not respond");
            logger.Critical("3/31/2015 5:23:54 PM", "No connection string found in App.config");


        }
    }
}