using System.Globalization;
using Medicines.Utilities;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models.Enums;
using TravelAgency.DataProcessor.ExportDtos;

namespace TravelAgency.DataProcessor
{
    public class Serializer
    {
        public static string ExportGuidesWithSpanishLanguageWithAllTheirTourPackages(TravelAgencyContext context)
        {
            var guides = context.Guides
                .Where(g => g.Language == Language.Spanish && g.TourPackagesGuides.Any())
                .OrderByDescending(g => g.TourPackagesGuides.Count)
                .ThenBy(g => g.FullName)
                .Select(g => new ExportGuideDTO()
                {
                    FullName = g.FullName,
                    TourPackages = g.TourPackagesGuides
                        .Where(tpg => tpg.Guide.Language == Language.Spanish)
                        .OrderByDescending(tp => tp.TourPackage.Price)
                        .ThenBy(tp => tp.TourPackage.PackageName)
                        .Select(tp => new ExportTourPackageDTO()
                        {
                            Name = tp.TourPackage.PackageName,
                            Description = tp.TourPackage.Description,
                            Price=tp.TourPackage.Price
                        })
                        .ToArray()
                })
                .ToArray();

            return XmlHelper.SerializeToXml(guides, "Guides");
        }

        public static string ExportCustomersThatHaveBookedHorseRidingTourPackage(TravelAgencyContext context)
        {
            var customers = context.Customers
                .Where(c => c.Bookings.Any(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .OrderByDescending(c => c.Bookings.Count(b => b.TourPackage.PackageName == "Horse Riding Tour"))
                .ThenBy(c => c.FullName)
                .Select(c => new
                {
                    c.FullName,
                    c.PhoneNumber,
                    Bookings = c.Bookings
                        .Where(b => b.TourPackage.PackageName == "Horse Riding Tour")
                        .OrderBy(b => b.BookingDate)
                        .Select(b => new
                        {
                            TourPackageName = b.TourPackage.PackageName,
                            Date = b.BookingDate.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture),
                        })
                        .ToArray()
                })
                .ToArray();


            return JsonConvert.SerializeObject(customers, Formatting.Indented);
        }
    }
}
