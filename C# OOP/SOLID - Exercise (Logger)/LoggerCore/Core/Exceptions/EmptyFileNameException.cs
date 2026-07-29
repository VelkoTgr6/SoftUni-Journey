using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class EmptyFileNameException : Exception
    {
        private const string defaultMessage = "File name cannot be null or whitespace";
        public EmptyFileNameException() 
            : base(defaultMessage)
        {

        }
        public EmptyFileNameException(string message)
            : base(message)
        {

        }
    }
}
