namespace Invoices.DataProcessor
{
    using AutoMapper;
    using Invoices.Data;
    using Invoices.Data.Models.Enums;
    using Invoices.DataProcessor.ExportDto;
    using Medicines.Utilities;
    using Newtonsoft.Json;
    using System.Globalization;
    using System.Text;
    using System.Xml.Serialization;

    public class Serializer
    {
        public static string ExportClientsWithTheirInvoices(InvoicesContext context, DateTime date)
        {
            var sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ExportClientsDTO[]), new XmlRootAttribute("Clients"));
            XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
            namespaces.Add(string.Empty, string.Empty);

            using StringWriter writer = new StringWriter(sb);

            var clients = context.Clients
                 .Where(c => c.Invoices.Any(i => i.IssueDate > date))
                 .Select(c => new ExportClientsDTO
                 {
                     InvoicesCount = c.Invoices.Count,
                     ClientName = c.Name,
                     VatNumber = c.NumberVat,
                     Invoices = c.Invoices
                     .Where(i => i.IssueDate > date)
                     .Select(i=>new ExportInvoiceDTO
                     {
                         InvoiceNumber =i.Number,
                         InvoiceAmount = i.Amount,
                         DueDate = i.DueDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture),
                         DueDateForOrder=i.DueDate,
                         Currency =i.CurrencyType,
                         IssueDate = i.IssueDate,

                     })
                     .OrderBy(i=>i.IssueDate)
                     .ThenByDescending(i=>i.DueDateForOrder)
                     .ToArray()
                     
                 })
                 .OrderByDescending(c=>c.InvoicesCount)
                 .ThenBy(c=>c.ClientName)
                 .ToArray();
            
            serializer.Serialize(writer, clients,namespaces);

            return sb.ToString().TrimEnd();
                
        }

        public static string ExportProductsWithMostClients(InvoicesContext context, int nameLength)
        {

            var clients = context.Products
                .Where(p => p.ProductsClients.Any(pc => pc.Client.Name.Length >= nameLength))
                .ToArray()
                .Select(p => new
                {
                    Name = p.Name,
                    Price = p.Price,
                    Category = p.CategoryType.ToString(),
                    Clients = p.ProductsClients
                    .Where(pc => pc.Client.Name.Length >= nameLength)
                    .ToArray()
                    .OrderBy(pc => pc.Client.Name)
                    .Select(p => new
                    {
                        Name = p.Client.Name,
                        NumberVat = p.Client.NumberVat
                    })
                    .ToArray()

                })
                .OrderByDescending(c => c.Clients.Count())
                .ThenBy(c => c.Name)
                .Take(5)
                .ToArray();

            var json = JsonConvert.SerializeObject(clients, Formatting.Indented);

            return json;
        }
    }
}