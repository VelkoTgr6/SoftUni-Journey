using Library.Core.Appernders.Interfaces;
using Library.Core.Enums;
using Library.Core.Layout.Interfaces;
using Library.Core.Loggers;
using Library.Core.Models;
using LoggerCore.Core.IO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Appernders
{
    public class FileAppender : IAppender
    {
        public FileAppender(ILayout layout,ILogFile logFile, ReportLevel reportLevel = ReportLevel.Info)
        {
            LogFile = logFile;
            ReportLevel = reportLevel;
            Layout = layout;
        }
        public ILogFile LogFile { get; private set; }
        public ReportLevel ReportLevel { get; set; }
        public int MessageAppended { get; set; }
        public ILayout Layout { get; private set; }

        public void Append(Message message)
        {
            string content=string.Format(Layout.Format,
                message.CreatedTime,
                message.ReportLevel,
                message.Text)+
                Environment.NewLine;

            File.AppendAllText(LogFile.FullPath, content);

            MessageAppended++;
        }
    }
}
