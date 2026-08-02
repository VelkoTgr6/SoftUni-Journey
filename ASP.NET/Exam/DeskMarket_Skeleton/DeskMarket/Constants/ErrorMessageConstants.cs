namespace DeskMarket.Constants
{
    public static class ErrorMessageConstants
    {
        /// <summary>
        /// Error Message requiring field to have value
        /// </summary>
        public const string RequireErrorMessage = "The field {0} is required";

        /// <summary>
        /// Error Message that gets the field name and sets the range of values that is required 
        /// </summary>
        public const string StringLengthErrorMessage = "The field {0} must be between {2} and {1} characters long";

        /// <summary>
        /// Error Message requiring the date of the filed to be in certain format
        /// </summary>
        public const string AddedOnFormatErrorMessage = "Added On date must be in the format dd-MM-yyyy";
    }
}
