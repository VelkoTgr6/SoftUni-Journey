

using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Client")]
    public class ExportClientsDTO
    {
        [XmlAttribute(nameof(InvoicesCount))]
        public int InvoicesCount {  get; set; }

        public string ClientName {  get; set; }

        public string VatNumber {  get; set; }

        [XmlArray("Invoices")]
        [XmlArrayItem("Invoice")]
        public ExportInvoiceDTO[] Invoices { get; set; }
    }
}
