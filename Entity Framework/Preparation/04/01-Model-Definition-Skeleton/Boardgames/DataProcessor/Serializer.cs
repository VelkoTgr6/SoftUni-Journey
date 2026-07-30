namespace Boardgames.DataProcessor
{
    using Boardgames.Data;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ExportDto;
    using Medicines.Utilities;
    using Newtonsoft.Json;

    public class Serializer
    {
        public static string ExportCreatorsWithTheirBoardgames(BoardgamesContext context)
        {
            var creators=context.Creators
                .Where(c=>c.Boardgames.Any())
                .Select(c=>new ExportCreatorDTO
                {
                    BoardgamesCount=c.Boardgames.Count(),
                    CreatorName=c.FirstName + " " + c.LastName,
                    Boardgames=c.Boardgames
                        .Select(b=> new ExportBoardgameDTO
                        {
                            BoardgameName=b.Name,
                            BoardgameYearPublished=b.YearPublished
                        })
                        .OrderBy(b=>b.BoardgameName)
                        .ToArray()
                })
                .OrderByDescending(b=>b.Boardgames.Count())
                .ThenBy(b=>b.CreatorName)
                .ToArray();

            var xml = XmlHelper.SerializeToXml(creators, "Creators");

            return xml;
        }

        public static string ExportSellersWithMostBoardgames(BoardgamesContext context, int year, double rating)
        {

            var sellers = context.Sellers
                .Where(s => s.BoardgamesSellers
                    .Any(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating))
                .Select(s => new
                {
                    Name = s.Name,
                    Website = s.Website,
                    Boardgames = s.BoardgamesSellers
                    .Where(bs => bs.Boardgame.YearPublished >= year && bs.Boardgame.Rating <= rating)
                    .Select(b => new
                    {
                        Name = b.Boardgame.Name,
                        Rating = b.Boardgame.Rating,
                        Mechanics = b.Boardgame.Mechanics,
                        Category = b.Boardgame.CategoryType.ToString(),
                    })
                    .OrderByDescending(b => b.Rating)
                    .ThenBy(b => b.Name)
                    .ToArray()
                })
                .OrderByDescending(s => s.Boardgames.Length)
                .ThenBy(s => s.Name)
                .Take(5)
                .ToArray();

            return JsonConvert.SerializeObject(sellers,Formatting.Indented);
        }
    }
}