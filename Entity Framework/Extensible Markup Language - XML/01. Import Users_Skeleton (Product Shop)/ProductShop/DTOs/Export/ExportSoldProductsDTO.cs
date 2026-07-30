

using System.Xml.Serialization;

namespace ProductShop.DTOs.Export
{
    [XmlType("User")]
    public class ExportSoldProductsDTO
    {
        [XmlElement("firstName")]
        public string FirstName {  get; set; }

        [XmlElement("lastName")]
        public string LastName { get; set; }

        [XmlArray("soldProducts")]
        public SoldProductsDTO[] SoldProducts { get; set; }
    }
}
