using System.Data.SqlClient;

namespace _4._Add_Minion
{
    internal class Program
    {
        static async Task Main(string minionInfo,string villianName)
        {
            string[]minionData= minionInfo.Split(' ');
            await Console.Out.WriteLineAsync(minionData[0]);

            #region Town
            SqlCommand
        }
    }
}
