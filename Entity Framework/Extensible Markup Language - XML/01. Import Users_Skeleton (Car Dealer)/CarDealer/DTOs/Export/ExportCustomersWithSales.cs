

using System.Xml.Serialization;

namespace CarDealer.DTOs.Export
{
    [XmlType("customer")]
    public class ExportCustomersWithSales
    {
        [XmlAttribute("full-name")]
        public string Name { get; set; }

        [XmlAttribute("bought-cars")]
        public int BoughtCars {  get; set; }

        [XmlIgnore]
        public decimal SpentMoney { get; set; }

        [XmlAttribute("spent-money")]
        public string SpentMoneyFormatted
        {
            get { return SpentMoney.ToString("F2"); }
            set { SpentMoney = decimal.Parse(value); }
        }

    }
}
