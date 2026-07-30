using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1._Initial_Setup
{
    internal class SQLqueries
    {
       public const string getVillans =
            "SELECT v.Name, COUNT(mv.VillainId) AS MinionsCount " +
        "FROM Villains AS v " +
        "JOIN MinionsVillains AS mv ON v.Id = mv.VillainId " +
        "GROUP BY v.Id, v.Name " +
        "HAVING COUNT(mv.VillainId) > 3 " +
        "ORDER BY COUNT(mv.VillainId)";
    }
}
