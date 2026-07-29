using Library.Core.Enums;
using Library.Core.Exceptions;
using Library.Core.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Models
{
    public class Message
    {
        private string createdTime;
        private string text;
        public Message(string createdTime, string text, ReportLevel reportLevel)
        {
            CreatedTime = createdTime;
            Text = text;
            ReportLevel = reportLevel;
        }
        public ReportLevel ReportLevel { get; set; }
        public string CreatedTime 
        {
            get => createdTime;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new EmtyCreatedTimeException();

                }
                if (!DateTimeValidator.ValidateDateTimeFormat(value))
                {
                    throw new InvalidDateTimeFormatException();
                }
                createdTime = value;
            } 
        }

        public string Text 
        { 
            get => text;
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new EmptyMessageTextException();

                }
                
                text = value; 
            }
        }
    }
}
