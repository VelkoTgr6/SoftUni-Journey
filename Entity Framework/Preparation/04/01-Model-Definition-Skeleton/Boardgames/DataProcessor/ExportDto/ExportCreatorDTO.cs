using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType("Creator")]
    public class ExportCreatorDTO
    {
        [XmlAttribute(nameof(BoardgamesCount))]
        public int BoardgamesCount {  get; set; }

        public string CreatorName {  get; set; }

        [XmlArray(nameof(Boardgames))]
        [XmlArrayItem("Boardgame")]
        public ExportBoardgameDTO[] Boardgames { get; set; }
    }
}
