using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class InvalidPathException : Exception
    {
        private const string defaultMessage = "Path is invalid or empty";
        public InvalidPathException()
            : base(defaultMessage)
        {

        }
        public InvalidPathException(string message)
            : base(message)
        {

        }
    }
}
