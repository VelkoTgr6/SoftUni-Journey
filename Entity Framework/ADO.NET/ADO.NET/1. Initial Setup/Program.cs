using System;
using System.Data.SqlClient;

namespace _1._Initial_Setup
{
    internal class Program
    {
        //Connection String
        const string _connectionString = "Server=VELKO-PC;Database=MinionsDB;Integrated Security=True";
        static void Main(string[] args)
        {
            //SqlConnection
            using SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            //Create SQLCommand
            using SqlCommand sqlCommand = new SqlCommand(SQLqueries.getVillans, sqlConnection);

            //Data reader
            using SqlDataReader reader = sqlCommand.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["Name"]} - {reader["MinionsCount"]}");
            }

        }
    }
}
