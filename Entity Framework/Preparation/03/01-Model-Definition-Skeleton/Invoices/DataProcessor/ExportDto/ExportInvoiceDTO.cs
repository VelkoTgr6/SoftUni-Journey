using Invoices.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ExportDto
{
    [XmlType("Invoice")]
    public class ExportInvoiceDTO
    {
        public int InvoiceNumber {  get; set; }
        public decimal InvoiceAmount {  get; set; }
        public string DueDate { get; set; }

        [XmlIgnore]
        public DateTime DueDateForOrder { get; set; }
        public CurrencyType Currency { get; set; }

        [XmlIgnore]
        public DateTime IssueDate { get; set; }
    }
}
