

namespace TravelAgency.Common
{
    public class ValidationConstants
    {
        //Customer
        public const int CustomerFullNameMinLength = 4;
        public const int CustomerFullNameMaxLength = 60;
        public const int CustomerEmailMinLength = 6;
        public const int CustomerEmailMaxLength = 50;
        public const string CustomerPhoneRegex = "^\\+\\d{12}$";

        //Guide
        public const int GuideFullNameMinLength = 4;
        public const int GuideFullNameMaxLength = 60;

        //TourPackage
        public const int PackageNameMinLength = 2;
        public const int PackageNameMaxLength = 40;
        public const int TourDescriptionMaxLength = 200;
    }
}
