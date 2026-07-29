using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telephony
{
    internal class StationaryPhone : ICalling
    {
        public string Call(string number)
        {
            if (!ValidateNummber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
            return $"Dialing... {number}";
        }
        private bool ValidateNummber(string number)
            => number.All(c => char.IsDigit(c));
    }
}
