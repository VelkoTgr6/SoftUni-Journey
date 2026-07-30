

using System.Xml.Serialization;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType("Despatcher")]
    public class ExportDespetcherDTO
    {
        [XmlAttribute(nameof(TrucksCount))]
        public string TrucksCount { get; set; }
        public string DespatcherName { get; set; }

        [XmlArray("Trucks")]
        [XmlArrayItem("Truck")]
        public ExportTruckDTO[] Trucks { get; set; }
    }
}
