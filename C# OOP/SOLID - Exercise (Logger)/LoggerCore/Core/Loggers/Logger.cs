using Library.Core.Appernders.Interfaces;
using Library.Core.Enums;
using Library.Core.Loggers.Interfaces;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Loggers
{
    public class Logger : ILogger
    {
        private readonly ICollection<IAppender> appenders;
        public Logger(params IAppender[]appenders)
        {
            this.appenders = appenders;
        }
        public void Critical(string dateTime, string message)
        {
            AppendAll(dateTime, message,ReportLevel.Critical);
        }

        public void Error(string dateTime, string message)
        {
            AppendAll(dateTime,message,ReportLevel.Error);
        }

        public void Fatal(string dateTime, string message)
        {
            AppendAll(dateTime,message, ReportLevel.Fatal);
        }

        public void Info(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Info);
        }

        public void Warning(string dateTime, string message)
        {
            AppendAll(dateTime, message, ReportLevel.Warning);
        }
        private void AppendAll(string dateTime,string text,ReportLevel reportLevel)
        {
            Message message = new(dateTime, text, reportLevel);

            foreach (var appender in appenders)
            {
                if (message.ReportLevel>=appender.ReportLevel)
                {
                    appender.Append(message);

                }
            }
        }
    }
}
