using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cadastre.Common
{
    public class ValidationConstants
    {
        //District
        public const int DistrictNameMinLength = 2;
        public const int DistrictNameMaxLength = 80;
        public const string DistrictPostalCodeRegex = "^[A-Z]{2}-\\d{5}$";

        //Property
        public const int PropertyIdentifierMinLength = 16;
        public const int PropertyIdentifierMaxLength = 20;
        public const int PropertyDetailsMinLegth = 5;
        public const int PropertyDetailsMaxLegth = 500;
        public const int PropertyAddressMinLegth = 5;
        public const int PropertyAddressMaxLegth = 200;
               
        //Citizen
        public const int CitizenFirstNameMinLegth = 2;
        public const int CitizenFirstNameMaxLegth = 30;
        public const int CitizenLastNameMinLegth = 2;
        public const int CitizenLastNameMaxLegth = 30;
    }
}
