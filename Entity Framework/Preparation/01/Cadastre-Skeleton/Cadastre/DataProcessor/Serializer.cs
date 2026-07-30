using Cadastre.Data;
using Cadastre.Data.Enumerations;
using Cadastre.DataProcessor.ExportDtos;
using Castle.DynamicProxy.Generators;
using Medicines.Utilities;
using Newtonsoft.Json;
using System;
using System.Globalization;

namespace Cadastre.DataProcessor
{
    public class Serializer
    {
        public static string ExportPropertiesWithOwners(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                 .Where(p => p.DateOfAcquisition >= new DateTime(2000, 1, 1))
                 .Select(p => new
                 {
                     PropertyIdentifier = p.PropertyIdentifier,
                     p.Area,
                     p.Address,
                     p.DateOfAcquisition,
                     Owners = p.PropertiesCitizens
                     .Where(pc => pc.Property.DateOfAcquisition >= new DateTime(2000, 1, 1))
                     .Select(pc => new
                     {
                         pc.Citizen.LastName,
                         MaritalStatus = pc.Citizen.MaritalStatus.ToString(),
                     })
                     .OrderBy(c => c.LastName)
                     .ToArray()
                 })
                 .OrderByDescending(p => p.DateOfAcquisition)
                 .ThenBy(p => p.PropertyIdentifier)
                 .ToArray();

            var result = properties.Select(p => new
            {
                p.PropertyIdentifier,
                p.Area,
                p.Address,
                DateOfAcquisition = p.DateOfAcquisition.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                p.Owners,
            })
            .ToArray();

                return JsonConvert.SerializeObject(result,Formatting.Indented);
        }

        public static string ExportFilteredPropertiesWithDistrict(CadastreContext dbContext)
        {
            var properties = dbContext.Properties
                .Where(p => p.Area >= 100)
                .Select(p => new ExportPropertyDTO
                {
                    PostalCode = p.District.PostalCode,
                    PropertyIdentifier = p.PropertyIdentifier,
                    Area = p.Area,
                    DateOfAcquisition =p.DateOfAcquisition.ToString("dd/MM/yyyy",CultureInfo.InvariantCulture),
                    DateForOrdering=p.DateOfAcquisition,
                })
                .OrderByDescending(p=>p.Area)
                .ThenBy (p => p.DateForOrdering)
                .ToArray();

            

            var xml = XmlHelper.SerializeToXml(properties, "Properties");

            return xml;
        }
    }
}
