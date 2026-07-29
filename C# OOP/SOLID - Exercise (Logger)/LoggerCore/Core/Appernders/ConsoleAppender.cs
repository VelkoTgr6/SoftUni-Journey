using Library.Core.Appernders.Interfaces;
using Library.Core.Enums;
using Library.Core.Layout.Interfaces;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Appernders
{
    public class ConsoleAppender : IAppender
    {
        public ConsoleAppender(ILayout layout, ReportLevel reportLevel = ReportLevel.Info)
        {
            ReportLevel = reportLevel;
            Layout = layout;
        }

        public ReportLevel ReportLevel { get; set; }

        public int MessageAppended { get; set; }

        public ILayout Layout { get; private set; }

        public void Append(Message message)
        {
            Console.WriteLine(string.Format(Layout.Format,
                message.CreatedTime,
                message.ReportLevel,
                message.Text));

            MessageAppended++;
        }
    }
}
