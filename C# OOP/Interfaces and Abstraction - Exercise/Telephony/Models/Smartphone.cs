using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telephony.Models.Interfaces;

namespace Telephony
{
    public class Smartphone : ICalling, IBrowsable
    {
        public string Call(string number)
        {
            if (!ValidateNummber(number))
            {
                throw new ArgumentException("Invalid number!");
            }
           return$"Calling... {number}";
        }
        public string Browse(string url)
        {
            if (!ValidateUrl(url))
            {
                throw new ArgumentException("Invalid URL!");
            }
            return $"Browsing: {url}!";
        }
        private bool ValidateNummber(string number) 
            => number.All(c=>char.IsDigit(c));
        private bool ValidateUrl(string url)=>url.All(c=>!char.IsDigit(c));

        
    }
}


    