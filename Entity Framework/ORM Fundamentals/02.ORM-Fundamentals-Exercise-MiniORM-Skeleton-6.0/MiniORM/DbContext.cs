namespace MiniORM
{
    public class DbContext
    {
        public static Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(long),
            typeof(uint),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };
    }
}
