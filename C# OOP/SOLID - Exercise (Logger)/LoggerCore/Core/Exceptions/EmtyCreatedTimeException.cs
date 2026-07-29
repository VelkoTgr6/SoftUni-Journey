using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Exceptions
{
    public class EmtyCreatedTimeException:Exception
    {
        private const string defaultMessage = "Created time of message cannot be null or whitespace";
        public EmtyCreatedTimeException()
            :base(defaultMessage)
        {
                
        }
        public EmtyCreatedTimeException(string message) 
            : base(message)
        {
                
        }
    }
}
