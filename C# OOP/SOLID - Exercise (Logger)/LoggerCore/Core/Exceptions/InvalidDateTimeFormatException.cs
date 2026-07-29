using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class InvalidDateTimeFormatException : Exception
    {
        private const string defaultMessage = "Invalid DataTime format";
        public InvalidDateTimeFormatException()
            : base(defaultMessage)
        {

        }
        public InvalidDateTimeFormatException(string message)
            : base(message)
        {

        }
    }
}
