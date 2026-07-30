using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    
    [XmlRoot("Users")]
    public class ExportUsersDTO
    {
        [XmlElement("count")]
        public int Count {  get; set; }

        [XmlArray("users")]
        public UserDataDTO[] Users { get; set; }
    }
}
