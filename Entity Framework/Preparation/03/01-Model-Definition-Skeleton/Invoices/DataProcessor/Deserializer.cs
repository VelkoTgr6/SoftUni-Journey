namespace Invoices.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;
    using Invoices.Data;
    using Invoices.Data.Models;
    using Invoices.DataProcessor.ImportDto;
    using Medicines.Utilities;
    using Microsoft.Data.SqlClient.Server;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedClients
            = "Successfully imported client {0}.";

        private const string SuccessfullyImportedInvoices
            = "Successfully imported invoice with number {0}.";

        private const string SuccessfullyImportedProducts
            = "Successfully imported product - {0} with {1} clients.";


        public static string ImportClients(InvoicesContext context, string xmlString)
        {
            var sb=new StringBuilder();

            ImportClientDTO[] importClientDTOs = XmlHelper.DeserializeFromXml<ImportClientDTO[]>(xmlString, "Clients");

            List<Client>validClients= new List<Client>();

            foreach (var clientDTO in importClientDTOs)
            {
                if (!IsValid(clientDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client = new Client
                {
                    Name = clientDTO.Name,
                    NumberVat = clientDTO.NumberVat,
                    Addresses =new List<Address>()
                };
                foreach (var addressDTO in clientDTO.Addresses)
                {
                    if (!IsValid(addressDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    var address = new Address
                    {
                        StreetName = addressDTO.StreetName,
                        StreetNumber = addressDTO.StreetNumber,
                        PostCode = addressDTO.PostCode,
                        City = addressDTO.City,
                        Country = addressDTO.Country
                    };

                    client.Addresses.Add(address);
                   
                }
                sb.AppendLine(string.Format(SuccessfullyImportedClients, client.Name));
                validClients.Add(client);
            }
            context.Clients.AddRange(validClients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }


        public static string ImportInvoices(InvoicesContext context, string jsonString)
        {
            StringBuilder sb = new StringBuilder();
            ImportInvoicesDTO[] invoicesDtos = JsonConvert.DeserializeObject<ImportInvoicesDTO[]>(jsonString);

            List<Invoice> invoices = new List<Invoice>();

            foreach (var invoiceDto in invoicesDtos)
            {
                if (!IsValid(invoiceDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (invoiceDto.DueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture) || invoiceDto.IssueDate == DateTime.ParseExact("01/01/0001", "dd/MM/yyyy", CultureInfo.InvariantCulture))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Invoice i = new Invoice()
                {
                    Number = invoiceDto.Number,
                    IssueDate = invoiceDto.IssueDate,
                    DueDate = invoiceDto.DueDate,
                    CurrencyType = invoiceDto.CurrencyType,
                    Amount = invoiceDto.Amount,
                    ClientId = invoiceDto.ClientId
                };

                if (i.IssueDate > i.DueDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                invoices.Add(i);
                sb.AppendLine(String.Format(SuccessfullyImportedInvoices, i.Number));
            }
            context.Invoices.AddRange(invoices);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        public static string ImportProducts(InvoicesContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportProductDTO[] importProductDTO = JsonConvert.DeserializeObject<ImportProductDTO[]>(jsonString);

            var validProducts=new List<Product>();

            foreach (var productDTO in importProductDTO)
            {
                if (!IsValid(productDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Product product = new Product
                {
                    Name = productDTO.Name,
                    Price = productDTO.Price,
                    CategoryType = productDTO.CategoryType,
                    ProductsClients = new List<ProductClient>()
                };

                foreach (var clientId in productDTO.Clients.Distinct())
                {
                    Client c = context.Clients.Find(clientId);

                    if (c == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    product.ProductsClients.Add(new ProductClient()
                    {
                        Client = c
                    });
                }
                sb.AppendLine(string.Format(SuccessfullyImportedProducts, product.Name, product.ProductsClients.Count()));
                validProducts.Add(product);
            }
            context.Products.AddRange(validProducts);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    } 
}
