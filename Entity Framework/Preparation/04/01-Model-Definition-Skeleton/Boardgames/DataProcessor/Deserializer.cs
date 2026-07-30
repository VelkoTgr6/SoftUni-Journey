namespace Boardgames.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Text;
    using Boardgames.Data;
    using Boardgames.Data.Models;
    using Boardgames.Data.Models.Enums;
    using Boardgames.DataProcessor.ImportDto;
    using Medicines.Utilities;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCreator
            = "Successfully imported creator – {0} {1} with {2} boardgames.";

        private const string SuccessfullyImportedSeller
            = "Successfully imported seller - {0} with {1} boardgames.";

        public static string ImportCreators(BoardgamesContext context, string xmlString)
        {
            var sb=new StringBuilder();

            ImportCreatorDTO[] importCreatorDTOs = XmlHelper.DeserializeFromXml<ImportCreatorDTO[]>(xmlString, "Creators");

            List<Creator> creators = new List<Creator>();

            foreach (var creatorDTO in importCreatorDTOs) 
            {
                if (!IsValid(creatorDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var creator = new Creator()
                {
                    FirstName = creatorDTO.FirstName,
                    LastName = creatorDTO.LastName,
                    Boardgames = new List<Boardgame>()
                };

                foreach (var boardgameDTO in creatorDTO.Boardgames)
                {
                    if (!IsValid(boardgameDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var boardgame = new Boardgame()
                    {
                        Name = boardgameDTO.Name,
                        Rating = boardgameDTO.Rating,
                        YearPublished = boardgameDTO.YearPublished,
                        CategoryType = (CategoryType)boardgameDTO.CategoryType,
                        Mechanics = boardgameDTO.Mechanics,
                    };

                    creator.Boardgames.Add(boardgame);
                }
                creators.Add(creator);
                sb.AppendLine(string.Format(SuccessfullyImportedCreator, creator.FirstName, creator.LastName, creator.Boardgames.Count));
            }

            context.AddRange(creators);
            context.SaveChanges();
            
            return sb.ToString().Trim();
        }

        public static string ImportSellers(BoardgamesContext context, string jsonString)
        {
            var sb= new StringBuilder();

            ImportSellerDTO[] importSellerDTOs=JsonConvert.DeserializeObject<ImportSellerDTO[]>(jsonString);

            List<Seller>sellers = new List<Seller>();

            var boardgamesIDs=context.Boardgames
                .Select(b=>b.Id)
                .ToArray();

            foreach (var sellerDTO in importSellerDTOs)
            {
                if (!IsValid(sellerDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var seller = new Seller()
                {
                    Name = sellerDTO.Name,
                    Address = sellerDTO.Address,
                    Country = sellerDTO.Country,
                    Website = sellerDTO.Website,
                    BoardgamesSellers=new List<BoardgameSeller>()
                };
                foreach (var boargameId in sellerDTO.Boardgames.Distinct())
                {
                    if (!boardgamesIDs.Contains(boargameId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    BoardgameSeller boardgameSeller = new BoardgameSeller()
                    {
                        BoardgameId = boargameId,
                        Seller = seller,
                    };

                    seller.BoardgamesSellers.Add(boardgameSeller);
                }
                sellers.Add(seller);
                sb.AppendLine(string.Format(SuccessfullyImportedSeller, seller.Name, seller.BoardgamesSellers.Count()));
            }

            context.AddRange(sellers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
