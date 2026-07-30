using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boardgames.Common
{
    public class ValidationConstants
    {
        //Boardgame
        public const int BoardGameNameMinLength = 10;
        public const int BoardGameNameMaxLength = 20;
        public const double BoardGameRattingMinRange = 1;
        public const double BoardGameRattingMaxRange = 10;
        public const int BoardGameYearPublishedMin = 2018;
        public const int BoardGameYearPublishedMax = 2023;

        //Seller
        public const int SellerNameMaxLength = 20;
        public const int SellerNameMinLength = 5;
        public const int SellerAddressMaxLength = 30;
        public const int SellerAddressMinLength = 2;
        public const string SellerWebsiteRegex = "^www\\.[a-zA-Z0-9-]+\\.com$";

        //Creator
        public const int CreatorFirstNameMinLength = 2;
        public const int CreatorFirstNameMaxLength = 7;
        public const int CreatorLastNameMinLength = 2;
        public const int CreatorLastNameMaxLength = 7;
    }
}
