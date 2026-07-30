

namespace Invoices.Common
{
    public class ValidationConstants
    {
        //Product
        public const int ProductNameMinLength = 9;
        public const int ProductNameMaxLength = 30;
        public const double ProductPriceMin = 5.00;
        public const double ProductPriceMax = 1000.00;

        //Address
        public const int AddressStreetNameMinLength = 10;
        public const int AddressStreetNameMaxLength = 20;
        public const int AddressCityNameMinLength = 5;
        public const int AddressCityNameMaxLength = 15;
        public const int AddressCountryNameMaxLength = 5;
        public const int AddressCountryNameMinLength = 15;

        //Invoices
        public const int InvoicesNumberMinRange = 1_000_000_000;
        public const int InvoicesNumberMaxRange = 1_500_000_000;

        //Client
        public const int ClientNameMinLength = 10;
        public const int ClientNameMaxLength = 25;
        public const int ClientNumberVatMaxLength = 15;
        public const int ClientNumberVatMinLength = 10;

    }
}
