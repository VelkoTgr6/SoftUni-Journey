

using System.Dynamic;

namespace Medicines.Common
{
    public class ValidationConstrains
    {
        //Pharmacy
        public const int PharmacyNameMinLength = 2;
        public const int PharmacyNameMaxLength = 50;
        public const string PharmacyPhoneRegex = "^\\(\\d{3}\\) \\d{3}-\\d{4}$";
        public const string PharmacyIsNonStopRegex = "^(true|false)$";

        //Medicine
        public const int MedicineNameMinLength = 3;
        public const int MedicineNameMaxLength = 150;
        public const double MedicinePriceMin = 0.01;
        public const double MedicinePriceMax = 1000.00;
        public const int MedicineProducerMin = 3;
        public const int MedicineProducerMax = 100;
        public const int MedicineCategoryMinValue = 0;
        public const int MedicineCategoryMaxValue = 4;

        //Patient
        public const int PatientNameMinLength = 5;
        public const int PatientNameMaxLength = 100;
    }
}
