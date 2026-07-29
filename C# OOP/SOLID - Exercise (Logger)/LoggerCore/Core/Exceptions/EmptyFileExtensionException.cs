using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class EmptyFileExtensionException : Exception
    {
        private const string defaultMessage = "Extension text cannot be null or whitespace";
        public EmptyFileExtensionException() 
            : base(defaultMessage)
        {

        }
        public EmptyFileExtensionException(string message)
            : base(message)
        {

        }
    }
}
