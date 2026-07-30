using Boardgames.Common;
using Boardgames.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ImportDto
{
    [XmlType("Boardgame")]
    public class ImportBoardgameDTO
    {
        [Required]
        [MinLength(ValidationConstants.BoardGameNameMinLength)]
        [MaxLength(ValidationConstants.BoardGameNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [Range(ValidationConstants.BoardGameRattingMinRange, ValidationConstants.BoardGameRattingMaxRange)]
        public double Rating { get; set; }

        [Required]
        [Range(ValidationConstants.BoardGameYearPublishedMin, ValidationConstants.BoardGameYearPublishedMax)]
        public int YearPublished { get; set; }

        [Required]
        public int CategoryType { get; set; }

        [Required]
        public string Mechanics { get; set; }
    }
}
