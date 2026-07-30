using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography;
using System.Text;
using Medicines.Utilities;
using Newtonsoft.Json;
using Trucks.Data.Models;
using Trucks.Data.Models.Enums;
using Trucks.DataProcessor.ImportDto;

namespace Trucks.DataProcessor
{
    using System.ComponentModel.DataAnnotations;
    using Data;


    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedDespatcher
            = "Successfully imported despatcher - {0} with {1} trucks.";

        private const string SuccessfullyImportedClient
            = "Successfully imported client - {0} with {1} trucks.";

        public static string ImportDespatcher(TrucksContext context, string xmlString)
        {
            ImportDespatcherDTO[] importDespatcherDtos =
                XmlHelper.DeserializeFromXml<ImportDespatcherDTO[]>(xmlString, "Despatchers");

            var sb = new StringBuilder();

            List<Despatcher> despatchers= new List<Despatcher>();

            foreach (var despatcherDto in  importDespatcherDtos)
            {
                if (!IsValid(despatcherDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Despatcher despatcher=new Despatcher()
                {
                    Name = despatcherDto.Name,
                    Position = despatcherDto.Position,
                    Trucks = new List<Truck>()
                    
                };

                foreach (var truckDto in despatcherDto.Trucks)
                {
                    if (!IsValid(truckDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Truck truck = new Truck()
                    {
                        RegistrationNumber = truckDto.RegistrationNumber,
                        VinNumber = truckDto.VinNumber,
                        TankCapacity = truckDto.TankCapacity,
                        CargoCapacity = truckDto.CargoCapacity,
                        CategoryType = (CategoryType)truckDto.CategoryType,
                        MakeType = (MakeType)truckDto.MakeType
                    };

                    despatcher.Trucks.Add(truck);
                }
                despatchers.Add(despatcher);
                sb.AppendLine(string.Format(SuccessfullyImportedDespatcher, despatcher.Name, despatcher.Trucks.Count));
            }

            context.AddRange(despatchers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        [SuppressMessage("ReSharper.DPA", "DPA0006: Large number of DB commands", MessageId = "count: 164")]
        public static string ImportClient(TrucksContext context, string jsonString)
        {
            ImportClientDTO[] importClientDtos = JsonConvert.DeserializeObject<ImportClientDTO[]>(jsonString);

            var sb= new StringBuilder();

            List<Client> clients = new List<Client>();

            foreach (var clientDto in importClientDtos)
            {
                if (!IsValid(clientDto) || clientDto.Type=="usual")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Client client= new Client()
                {
                    Name = clientDto.Name,
                    Nationality = clientDto.Nationality,
                    Type = clientDto.Type,
                    ClientsTrucks = new List<ClientTruck>()
                };

                foreach (var truckId in clientDto.Trucks.Distinct())
                {
                    if (!context.Trucks.Any(t=>t.Id == truckId) && !client.ClientsTrucks.Any(ct=>ct.TruckId == truckId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    ClientTruck clientTruck = new ClientTruck()
                    {
                        Client = client,
                        TruckId = truckId
                    };

                    client.ClientsTrucks.Add(clientTruck);
                }
                clients.Add(client);
                sb.AppendLine(string.Format(SuccessfullyImportedClient, client.Name, client.ClientsTrucks.Count));
            }

            context.AddRange(clients);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}