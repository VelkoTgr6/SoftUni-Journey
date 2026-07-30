namespace Cadastre.DataProcessor
{
    using Cadastre.Data;
    using Cadastre.Data.Enumerations;
    using Cadastre.Data.Models;
    using Cadastre.DataProcessor.ImportDtos;
    using Medicines.Utilities;
    using Microsoft.Data.SqlClient.Server;
    using Newtonsoft.Json;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.Text;

    public class Deserializer
    {
        private const string ErrorMessage =
            "Invalid Data!";
        private const string SuccessfullyImportedDistrict =
            "Successfully imported district - {0} with {1} properties.";
        private const string SuccessfullyImportedCitizen =
            "Succefully imported citizen - {0} {1} with {2} properties.";

        public static string ImportDistricts(CadastreContext dbContext, string xmlDocument)
        {
            ImportDistrictDTO[] importDistrictDTOs = XmlHelper.DeserializeFromXml<ImportDistrictDTO[]>(xmlDocument, "Districts");

            var sb=new StringBuilder();

            List<District> districts = new List<District>();

            foreach (var districtDTO in importDistrictDTOs)
            {
                if (!IsValid(districtDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (districts.Any(d=>d.Name == districtDTO.Name) || dbContext.Districts.Any(d => d.Name == districtDTO.Name))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                District district = new District()
                {
                    Name = districtDTO.Name,
                    PostalCode = districtDTO.PostalCode,
                    Region = districtDTO.Region,
                    Properties=new List<Property>()
                };
                foreach (var propertyDTO in districtDTO.Properties)
                {
                    if (!IsValid(propertyDTO))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    if (district.Properties.Any(p => p.PropertyIdentifier == propertyDTO.PropertyIdentifier) ||
                         districts.Any(d => d.Properties.Any(p => p.PropertyIdentifier == propertyDTO.PropertyIdentifier)) ||
                            dbContext.Properties.Any(p => p.PropertyIdentifier == propertyDTO.PropertyIdentifier))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime date;
                    if (!DateTime.TryParseExact(propertyDTO.DateOfAcquisition, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Property property = new Property()
                    {
                        PropertyIdentifier = propertyDTO.PropertyIdentifier,
                        Area = propertyDTO.Area,
                        Details = propertyDTO.Details,
                        Address = propertyDTO.Address,
                        DateOfAcquisition = date
                    };
                    district.Properties.Add(property);
                }
                districts.Add(district);
                sb.AppendLine(string.Format(SuccessfullyImportedDistrict,district.Name,district.Properties.Count));
            }
            dbContext.AddRange(districts);
            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportCitizens(CadastreContext dbContext, string jsonDocument)
        {
            ImportCitizenDTO[] importCitizenDTO=JsonConvert.DeserializeObject<ImportCitizenDTO[]>(jsonDocument);

            var sb=new StringBuilder();

            List<Citizen> citizens = new List<Citizen>();

            foreach (var citizenDTO in importCitizenDTO)
            {
                if (!IsValid(citizenDTO))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime date;
                if (!DateTime.TryParseExact(citizenDTO.BirthDate, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                
                if (citizenDTO.MaritalStatus != "Unmarried"  && citizenDTO.MaritalStatus != "Married" &&
                    citizenDTO.MaritalStatus != "Divorced" && citizenDTO.MaritalStatus != "Widowed")
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                if (!Enum.TryParse<MaritalStatus>(citizenDTO.MaritalStatus, out MaritalStatus maritalStatus))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                Citizen citizen = new Citizen()
                {
                    FirstName= citizenDTO.FirstName,
                    LastName= citizenDTO.LastName,
                    BirthDate=date,
                    MaritalStatus=maritalStatus,
                    PropertiesCitizens=new List<PropertyCitizen>()
                };
                foreach (var propertyId in citizenDTO.Properties)
                {
                    if (!dbContext.Properties.Any(p=>p.Id == propertyId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }
                    PropertyCitizen propertyCitizen = new PropertyCitizen()
                    {
                        Citizen = citizen,
                        PropertyId= propertyId
                    };

                    citizen.PropertiesCitizens.Add(propertyCitizen);
                }
                citizens.Add (citizen);
                sb.AppendLine(string.Format(SuccessfullyImportedCitizen,citizen.FirstName,citizen.LastName,citizen.PropertiesCitizens.Count));
            }
            dbContext.AddRange(citizens);
            dbContext.SaveChanges();

            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}
