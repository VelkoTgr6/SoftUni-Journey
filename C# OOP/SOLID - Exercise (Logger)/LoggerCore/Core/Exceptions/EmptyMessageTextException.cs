using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class EmptyMessageTextException : Exception
    {
        private const string defaultMessage = "Message text cannot be null or whitespace";
        public EmptyMessageTextException() 
            : base(defaultMessage)
        {

        }
        public EmptyMessageTextException(string message)
            : base(message)
        {

        }
    }
}
