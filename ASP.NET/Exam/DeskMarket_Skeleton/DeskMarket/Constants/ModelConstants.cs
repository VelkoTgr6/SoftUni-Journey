namespace DeskMarket.Constants
{
    public static class ModelConstants
    {
        /// <summary>
        /// Product Name Minimum Length
        /// </summary>
        public const int ProductNameMinLength = 2;

        /// <summary>
        /// Product Name Maximum Length
        /// </summary>
        public const int ProductNameMaxLength = 60;

        /// <summary>
        /// Product Description Minimum Length
        /// </summary>
        public const int ProductDescriptionMinLength = 10;

        /// <summary>
        /// Product Description Maximum Length
        /// </summary>
        public const int ProductDescriptionMaxLength = 250;

        /// <summary>
        /// Product Price Minimum Length
        /// </summary>
        public const double ProductPriceMinValue = 1.00;

        /// <summary>
        /// Product Price Maximum Length
        /// </summary>
        public const double ProductPriceMaxValue = 3000.00;

        /// <summary>
        /// Product Name Minimum Length
        /// </summary>
        public const int CategoryNameMinLength = 3;

        /// <summary>
        /// Product Name Maximum Length
        /// </summary>
        public const int CategoryNameMaxLength = 20;

        /// <summary>
        /// Date Format string 
        /// </summary>
        public const string DateFormat = "dd-MM-yyyy";

        /// <summary>
        /// Date format Regular Expression to match the Date Format
        /// </summary>
        public const string RegexDateFormat = @"^(0[1 - 9]|[12][0 - 9]|3[01])-(0[1 - 9]|1[0 - 2])-(\d{4})$";
    }
}
