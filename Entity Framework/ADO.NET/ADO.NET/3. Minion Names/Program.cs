using System.Data.SqlClient;

namespace _3._Minion_Names
{
    internal class Program
    {
        const string connectionString = "Server=VELKO-PC;Database=MinionsDB;Integrated Security=True";
        static SqlConnection? connection;
        static async Task Main(string[] args)
        {
            try
            {
                connection = new SqlConnection(connectionString);
                connection.Open();

                //int id = int.Parse(Console.ReadLine());

                //await GetOrderedMinionsByVillianId(id);

                await UpdateTownNamesToUppercase("Bulgaria");

            }
            finally
            {
                connection?.Close();
            }
        }

        static async Task GetOrderedMinionsByVillianId(int id)
        {
            using SqlCommand cmd = new SqlCommand(SQLqueries.queryDeclarable, connection);
            cmd.Parameters.AddWithValue("@Id", id);
            var result = await cmd.ExecuteScalarAsync();

            if (result is null)
            {
                await Console.Out.WriteLineAsync($"No villain with ID {id} exists in the database.");
            }
            else
            {
                await Console.Out.WriteLineAsync($"Vilain: {result}");

                using SqlCommand commandGetMinionsData = new SqlCommand(SQLqueries.query, connection);
                commandGetMinionsData.Parameters.AddWithValue("@Id", id);

                var minionsReader = await commandGetMinionsData.ExecuteReaderAsync();

                while (await minionsReader.ReadAsync())
                {
                    await Console.Out.WriteLineAsync($"{minionsReader["RowNum"]}."
                        + $"{minionsReader["Name"]}" + $"{minionsReader["Age"]} ");
                }
            }
        }

        //4
        static async Task AddMinions(string minionInfo, string villianName)
        {
            using SqlTransaction transaction = connection.BeginTransaction();

            string[] minionData = minionInfo.Split(' ');
            string minionName = minionData[0];
            int minionAge = int.Parse(minionData[1]);
            string minionTown = minionData[2];

            await Console.Out.WriteLineAsync(minionData[0]);

            try
            {

                #region Town
                using SqlCommand cmdGetTownId = new SqlCommand(SQLqueries.getTownByName, connection, transaction);
                cmdGetTownId.Parameters.AddWithValue("@townName", minionTown);

                var townResult = await cmdGetTownId.ExecuteScalarAsync();

                int townId = -1;

                if (townResult is null)
                {
                    using SqlCommand cmdAddTown = new SqlCommand(SQLqueries.InsertNewTown, connection, transaction);
                    cmdAddTown.Parameters.AddWithValue("@townName", minionTown);
                    townId = Convert.ToInt32(await cmdAddTown.ExecuteScalarAsync());
                    await Console.Out.WriteLineAsync($"Town {minionTown} was added to the database");
                }
                else
                {
                    townId = (int)townResult;
                }
                #endregion

                #region Villian
                using SqlCommand cmdGetVillian = new SqlCommand(SQLqueries.getVillainByName, connection, transaction);
                cmdGetVillian.Parameters.AddWithValue("@villainName", villianName);
                var villainResult = await cmdGetVillian.ExecuteScalarAsync();

                int villainId = -1;
                if (villainResult is null)
                {
                    using SqlCommand sqlAddVillain = new SqlCommand(SQLqueries.InsertNewVillain, connection, transaction);
                    sqlAddVillain.Parameters.AddWithValue($"@villainName", villianName);
                    sqlAddVillain.Parameters.AddWithValue($"@evilFactorId", 4);

                    villainId = Convert.ToInt32(await sqlAddVillain.ExecuteScalarAsync());

                    await Console.Out.WriteLineAsync($"Villian {villianName} was added to the database");
                }
                else
                {
                    villainId = (int)villainResult;
                }


                #endregion

                #region Minion
                using SqlCommand cmdInserMinion = new SqlCommand(SQLqueries.InsertNewMinion, connection, transaction);
                cmdInserMinion.Parameters.AddWithValue("@minionName", minionName);
                cmdInserMinion.Parameters.AddWithValue("@minionAge", minionAge);
                cmdInserMinion.Parameters.AddWithValue("@townId", townId);
                await Console.Out.WriteLineAsync($"Minion {minionName} was added to the database");

                int minionId = Convert.ToInt32(await cmdInserMinion.ExecuteScalarAsync());
                using SqlCommand cmdInsertMinionVillain = new SqlCommand(SQLqueries.InsertMinionsVillains, connection, transaction);
                await cmdInsertMinionVillain.ExecuteNonQueryAsync();
                await Console.Out.WriteLineAsync($"Successfully added {minionName} was added as servent to {villianName}");
                #endregion

                transaction.Commit();
            }
            catch
            {
                transaction.Rollback();
            }
        }

        //5
        static async Task UpdateTownNamesToUppercase(string countryName)
        {
            List<string> changedTowns = new List<string>();

            // Begin transaction
            using (SqlTransaction transaction = connection.BeginTransaction())
            {
                try
                {
                    // Fetch towns in the specified country
                   

                    using (SqlCommand selectCmd = new SqlCommand(SQLqueries.query3, connection, transaction))
                    {
                        selectCmd.Parameters.AddWithValue("@countryName", countryName);

                        using (SqlDataReader reader = await selectCmd.ExecuteReaderAsync())
                        {
                            while (await reader.ReadAsync())
                            {
                                string townName = reader["Name"].ToString();
                                changedTowns.Add(townName);
                            }
                        }
                    }

                    // If no towns found, print message and rollback transaction
                    if (changedTowns.Count == 0)
                    {
                        Console.WriteLine("No town names were affected.");
                        transaction.Rollback();
                        return;
                    }

                    // Update towns to uppercase

                    using (SqlCommand updateCmd = new SqlCommand(SQLqueries.updateTownName, connection, transaction))
                    {
                        updateCmd.Parameters.AddWithValue("@countryName", countryName);
                        await updateCmd.ExecuteNonQueryAsync();
                    }

                    // Commit transaction
                    transaction.Commit();

                    // Print result
                    Console.WriteLine($"{changedTowns.Count} town names were affected.");
                    Console.WriteLine($"[{string.Join(", ", changedTowns).ToUpper()}]");
                }
                catch (Exception ex)
                {
                    // Rollback transaction on error
                    Console.WriteLine("An error occurred while updating the town names.");
                    Console.WriteLine(ex.Message);
                    transaction.Rollback();
                }



            }

        }
    }
}
    
