using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using Medicines.Utilities;
using Newtonsoft.Json;
using TravelAgency.Data;
using TravelAgency.Data.Models;
using TravelAgency.DataProcessor.ImportDtos;

namespace TravelAgency.DataProcessor
{
    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data format!";
        private const string DuplicationDataMessage = "Error! Data duplicated.";
        private const string SuccessfullyImportedCustomer = "Successfully imported customer - {0}";
        private const string SuccessfullyImportedBooking = "Successfully imported booking. TourPackage: {0}, Date: {1}";

        public static string ImportCustomers(TravelAgencyContext context, string xmlString)
        {
            ImportCustomerDTO[] importCustomerDtos =
                XmlHelper.DeserializeFromXml<ImportCustomerDTO[]>(xmlString, "Customers");

            var sb = new StringBuilder();

            List<Customer> customers = new List<Customer>();

            foreach (var customerDto in importCustomerDtos)
            {
                if (!IsValid(customerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (customers.Any(c=>c.Email==customerDto.Email || 
                                     c.FullName==customerDto.FullName || c.PhoneNumber==customerDto.PhoneNumber))
                {
                    sb.AppendLine(DuplicationDataMessage);
                    continue;
                }

                Customer customer = new Customer()
                {
                    PhoneNumber = customerDto.PhoneNumber,
                    FullName = customerDto.FullName,
                    Email = customerDto.Email
                };
                customers.Add(customer);
                sb.AppendLine(string.Format(SuccessfullyImportedCustomer, customer.FullName));
            }
            context.AddRange(customers);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        public static string ImportBookings(TravelAgencyContext context, string jsonString)
        {
            ImportBookingDTO[] importBookingDtos = JsonConvert.DeserializeObject<ImportBookingDTO[]>(jsonString);

            var sb = new StringBuilder();

            List<Booking> bookings = new List<Booking>();

            foreach (var bookingDto in importBookingDtos)
            {
                if (!IsValid(bookingDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var customer = context.Customers
                    .FirstOrDefault(c => c.FullName == bookingDto.CustomerName);
                var tourPackage = context.TourPackages
                    .FirstOrDefault(tp => tp.PackageName == bookingDto.TourPackageName);

                //if (customer == null || tourPackage == null)
                //{
                //    sb.AppendLine(ErrorMessage);
                //    continue;
                //}

                
                bool isValidDate = DateTime.TryParseExact(bookingDto.BookingDate, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime date);

                if (!isValidDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Booking booking = new Booking()
                {
                    BookingDate =
                       date,
                    CustomerId = customer.Id,
                    TourPackageId = tourPackage.Id
                };

                bookings.Add(booking);
                sb.AppendLine(string.Format(SuccessfullyImportedBooking, bookingDto.TourPackageName,
                    bookingDto.BookingDate));
            }
            context.AddRange(bookings);
            context.SaveChanges();

            return sb.ToString().TrimEnd();


        }

        public static bool IsValid(object dto)
        {
            var validateContext = new ValidationContext(dto);
            var validationResults = new List<ValidationResult>();

            bool isValid = Validator.TryValidateObject(dto, validateContext, validationResults, true);

            foreach (var validationResult in validationResults)
            {
                string currValidationMessage = validationResult.ErrorMessage;
            }

            return isValid;
        }
    }
}
