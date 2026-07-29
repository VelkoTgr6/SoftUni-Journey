using Library.Core.Enums;
using Library.Core.Layout.Interfaces;
using Library.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Appernders.Interfaces
{
    public interface IAppender
    {
        ILayout Layout { get; }
        ReportLevel ReportLevel { get; set; }
        int MessageAppended { get; }
        void Append(Message message);
    }
}
