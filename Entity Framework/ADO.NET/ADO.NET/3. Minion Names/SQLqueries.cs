using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _3._Minion_Names
{
    internal class SQLqueries
    {
        public const string query = @"SELECT ROW_NUMBER() OVER(ORDER BY m.Name) AS RowNum,
                                         m.Name, 
                                         m.Age
                                    FROM MinionsVillains AS mv
                                    JOIN Minions As m ON mv.MinionId = m.Id
                                   WHERE mv.VillainId = @Id
                                ORDER BY m.Name";

        public const string queryDeclarable = @"SELECT Name FROM Villains WHERE Id = @Id";

        public const string query2 = @"SELECT Id FROM Minions WHERE Name = @Name
                                    INSERT INTO MinionsVillains (MinionId, VillainId) VALUES (@minionId, @villainId)
                                    INSERT INTO Villains (Name, EvilnessFactorId)  VALUES (@villainName, 4)
                                    INSERT INTO Minions (Name, Age, TownId) VALUES (@name, @age, @townId)
                                    INSERT INTO Towns (Name) VALUES (@townName)
                                    SELECT Id FROM Towns WHERE Name = @townName";

        public const string getTownByName = @"SELECT Id FROM Towns WHERE Name = @Name";
        public const string getVillainByName = @"SELECT Id FROM Villians WHERE Name = @villainName";

        public const string InsertNewTown = @"INSERT INTO Towns ([Name]) OUTPUT inserted.Id VALUES(@townName)";
        public const string InsertNewVillain = @"INSERT INTO Villains ([Name],EvilnessFactorId) OUTPUT inserted.Id VALUES(@villainName,@evilnessFactorId)";
        public const string InsertNewMinion = @"INSERT INTO Towns ([Name],Age,TownId) OUTPUT inserted.Id VALUES(@minionName,@minionAge,@townId)";
        public const string InsertMinionsVillains = @"INSERT INTO MinnionsVillains(MinionId,VillainId) VALUES (@minionId,@villainId)";


        public const string query3 = @"SELECT t.Name 
                                         FROM Towns as t
                                         JOIN Countries AS c ON c.Id = t.CountryCode
                                         WHERE c.Name = @countryName";

        public const string updateTownName = @"UPDATE Towns
                                                SET Name = UPPER(Name)
                                                WHERE CountryCode = (SELECT c.Id FROM Countries AS c WHERE c.Name = @countryName)";
        

    }
}
